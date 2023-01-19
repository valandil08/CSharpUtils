namespace CSharpUtils.Storage
{
    public static class InMemoryCache
    {
        private static Dictionary<string, string> cache = new Dictionary<string, string>();
        private static List<Thread> updateThreads = new List<Thread>();

        private class CachedData
        {
            public string? Value { get; set; }
            public DateTime WhenExpires { get; set; }
        }

        public static string? GetValue(string name)
        {
            return !cache.ContainsKey(name) ? null : cache[name];
        }

        public static bool IsRegistered(string name)
        {
            return cache.ContainsKey(name);
        }

        public static bool RegisterCacheEntry(string name, Func<string> getFunction, int secondsBetweenUpdates)
        {
            string value = getFunction.Invoke();

            if (value == null)
            {
                return false;
            }

            cache.Add(name, value);

            Thread thread = new Thread(() =>
            {
                DateTime nextUpdate = DateTime.Now.AddSeconds(secondsBetweenUpdates);

                while (true)
                {
                    if (DateTime.Now < nextUpdate)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        string value = getFunction.Invoke();
                        cache[name] = value;
                        nextUpdate = DateTime.Now.AddSeconds(secondsBetweenUpdates);
                    }
                }
            });

            thread.IsBackground = true;

            updateThreads.Add(thread);

            thread.Start();

            return true;
        }
    }
}
