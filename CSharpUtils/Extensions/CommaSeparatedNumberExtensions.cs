using System.Text;

namespace CSharpUtils.Extensions
{
    public static class CommaSeparatedNumberExtensions
    {
        public static string ToCommaSeparatedText(this short number)
        {
            return ToCommaSeparatedText(number.ToString(), number < 0);
        }
        public static string ToCommaSeparatedText(this int number)
        {
            return ToCommaSeparatedText(number.ToString(), number < 0);
        }
        public static string ToCommaSeparatedText(this long number)
        {
            return ToCommaSeparatedText(number.ToString(), number < 0);
        }

        private static string ToCommaSeparatedText(string text, bool isNegative)
        {
            StringBuilder sb = new StringBuilder();

            byte counter = 0;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (i == 0 && isNegative)
                {
                    continue;
                }

                if (counter == 3)
                {
                    sb.Insert(0, ",");
                    counter = 0;
                }

                sb.Insert(0, text[i]);
                counter++;
            }

            if (isNegative)
            {
                sb.Insert(0, "-");
            }

            return sb.ToString();
        }
    }
}
