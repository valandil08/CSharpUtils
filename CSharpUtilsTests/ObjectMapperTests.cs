using CSharpUtils.DataProcessing;

namespace CSharpUtilsTests
{
    public class ObjectMapperTests
    {

        [Test, Order(1)]
        public void RegisterMap()
        {
            try
            {
                bool created = ObjectMapper.RegisterMap<string, int>(x => int.Parse(x));

                Assert.IsTrue(created);

                bool exists = ObjectMapper.IsRegistered(typeof(string), typeof(int));

                Assert.IsTrue(exists);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test, Order(2)]
        public void PerformanceTest()
        {
            try
            {
                /* map to self to remove any extra delay caused by casting or mapping */
                bool exists = ObjectMapper.IsRegistered(typeof(int), typeof(int));

                if (!exists)
                {
                    ObjectMapper.RegisterMap<int, int>(x => x);
                }

                double[] timings = new double[10000];

                DateTime startTime, endTime;

                // call the map function 10,000 times and
                // ensure the average is less than 1 microseconds
                for (int i = 0; i < 10000; i++)
                {
                    startTime = DateTime.Now;

                    ObjectMapper.Map<int>(12);

                    endTime = DateTime.Now;

                    // generate timing and to microseconds
                    timings[i] = (endTime - startTime).TotalMilliseconds * 1000; 
                }

                double averageTime = timings.Average();

                // ensure performance below 1 microseconds
                Assert.IsTrue(averageTime < 1);
            }
            catch
            {
                Assert.Fail();
            }
        }

    }
}