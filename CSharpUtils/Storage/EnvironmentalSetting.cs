namespace CSharpUtils.Storage
{
    public class EnvironmentalSettingData
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }

    public static class EnvironmentalSetting
    {
        private static Dictionary<string, string> environmentalSettings = new Dictionary<string, string>();

        public static string? GetValue(string name)
        {
            if (environmentalSettings.ContainsKey(name))
            {
                return environmentalSettings[name];
            }
            else
            {
                return null;
            }
        }

        public static bool AddOrUpdateValue(EnvironmentalSettingData setting)
        {
            if (setting == null || setting.Name == null || setting.Value == null)
            {
                return false;
            }

            return AddOrUpdateValue(setting.Name, setting.Value);
        }
    
        public static bool AddOrUpdateValue(string name, string value)
        {
            if (name == null || value == null)
            {
                return false;
            }

            try
            {
                if (environmentalSettings.ContainsKey(name))
                {
                    environmentalSettings[name] = value;
                }
                else
                {
                    environmentalSettings.Add(name, value);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
