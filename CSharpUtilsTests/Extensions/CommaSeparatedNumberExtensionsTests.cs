using CSharpUtils.Extensions;

namespace CSharpUtilsTests.Extensions
{
    [Parallelizable(ParallelScope.All)]
    public class CommaSeparatedNumberExtensionsTests
    {

        [TestCase(1, 0)]
        [TestCase(10, 0)]
        [TestCase(100, 0)]
        [TestCase(1000, 1)]
        [TestCase(10000, 1)]
        [TestCase(-1, 0)]
        [TestCase(-10, 0)]
        [TestCase(-100, 0)]
        [TestCase(-1000, 1)]
        [TestCase(-10000, 1)]
        public void ConvertShortToCommaSeparatedText(short number, int numberOfCommas)
        {
            string numberAsText = number.ToCommaSeparatedText();

            // ensure number of commas is correct
            Assert.IsTrue(numberAsText.Count(x => x == ',') == numberOfCommas);

            // ensure does not start with a comma
            Assert.IsTrue(numberAsText[0] != ',');

            if (number < 0)
            {
                // ensure starts with a dash
                Assert.IsTrue(numberAsText[0] == '-');
            }
            else
            {
                // ensure does not start with a dash
                Assert.IsTrue(numberAsText[0] != '-');
            }

            // ensure the number of characters between each comma barring the first section is 3
            string[] array = numberAsText.Split(',');

            for (int i = 1; i < array.Length; i++)
            {
                Assert.IsTrue(array[i].Length == 3);
            }
        }


        [TestCase(1, 0)]
        [TestCase(10, 0)]
        [TestCase(100, 0)]
        [TestCase(1000, 1)]
        [TestCase(10000, 1)]
        [TestCase(100000, 1)]
        [TestCase(1000000, 2)]
        [TestCase(10000000, 2)]
        [TestCase(100000000, 2)]
        [TestCase(1000000000, 3)]
        [TestCase(-1, 0)]
        [TestCase(-10, 0)]
        [TestCase(-100, 0)]
        [TestCase(-1000, 1)]
        [TestCase(-10000, 1)]
        [TestCase(-100000, 1)]
        [TestCase(-1000000, 2)]
        [TestCase(-10000000, 2)]
        [TestCase(-100000000, 2)]
        [TestCase(-1000000000, 3)]
        public void ConvertIntToCommaSeparatedText(int number, int numberOfCommas)
        {
            string numberAsText = number.ToCommaSeparatedText();

            // ensure number of commas is correct
            Assert.IsTrue(numberAsText.Count(x => x == ',') == numberOfCommas);

            // ensure does not start with a comma
            Assert.IsTrue(numberAsText[0] != ',');

            if (number < 0)
            {
                // ensure starts with a dash
                Assert.IsTrue(numberAsText[0] == '-');
            }
            else
            {
                // ensure does not start with a dash
                Assert.IsTrue(numberAsText[0] != '-');
            }

            // ensure the number of characters between each comma barring the first section is 3
            string[] array = numberAsText.Split(',');

            for (int i = 1; i < array.Length; i++)
            {
                Assert.IsTrue(array[i].Length == 3);
            }
        }


        [TestCase(1, 0)]
        [TestCase(10, 0)]
        [TestCase(100, 0)]
        [TestCase(1000, 1)]
        [TestCase(10000, 1)]
        [TestCase(100000, 1)]
        [TestCase(1000000, 2)]
        [TestCase(10000000, 2)]
        [TestCase(10000000, 2)]
        [TestCase(1000000000, 3)]
        [TestCase(10000000000, 3)]
        [TestCase(100000000000, 3)]
        [TestCase(1000000000000, 4)]
        [TestCase(-1, 0)]
        [TestCase(-10, 0)]
        [TestCase(-100, 0)]
        [TestCase(-1000, 1)]
        [TestCase(-10000, 1)]
        [TestCase(-100000, 1)]
        [TestCase(-1000000, 2)]
        [TestCase(-10000000, 2)]
        [TestCase(-100000000, 2)]
        [TestCase(-1000000000, 3)]
        [TestCase(-10000000000, 3)]
        [TestCase(-100000000000, 3)]
        [TestCase(-1000000000000, 4)]
        public void ConvertLongToCommaSeparatedText(long number, int numberOfCommas)
        {
            string numberAsText = number.ToCommaSeparatedText();

            // ensure number of commas is correct
            Assert.IsTrue(numberAsText.Count(x => x == ',') == numberOfCommas);

            // ensure does not start with a comma
            Assert.IsTrue(numberAsText[0] != ',');

            if (number < 0)
            {
                // ensure starts with a dash
                Assert.IsTrue(numberAsText[0] == '-');
            }
            else
            {
                // ensure does not start with a dash
                Assert.IsTrue(numberAsText[0] != '-');
            }

            // ensure the number of characters between each comma barring the first section is 3
            string[] array = numberAsText.Split(',');

            for (int i = 1; i < array.Length; i++)
            {
                Assert.IsTrue(array[i].Length == 3);
            }
        }


    }
}
