namespace CSharpUtils.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetDaySuffix(this DateTime dateTime)
        {
            switch (dateTime.Day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="toLowerCase"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string GetDayOfWeekAsText(this DateTime dateTime, bool toLowerCase = false, int maxLength = 0)
        {
            string value;

            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    value = "Monday";
                    break;

                case DayOfWeek.Tuesday:
                    value = "Tuesday";
                    break;

                case DayOfWeek.Wednesday:
                    value = "Wednesday";
                    break;

                case DayOfWeek.Thursday:
                    value = "Thursday";
                    break;

                case DayOfWeek.Friday:
                    value = "Friday";
                    break;

                case DayOfWeek.Saturday:
                    value = "Saturday";
                    break;

                default:
                    value = "Sunday";
                    break;
            }

            if (maxLength != 0)
            {
                value = value.Substring(0, maxLength);
            }

            if (toLowerCase)
            {
                value = value.ToLower();
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="toLowerCase"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string GetMonthAsText(this DateTime dateTime, bool toLowerCase = false, int maxLength = 0)
        {
            string value;

            switch (dateTime.Month)
            {
                case 1:
                    value = "January";
                    break;

                case 2:
                    value = "February";
                    break;

                case 3:
                    value = "March";
                    break;

                case 4:
                    value = "April";
                    break;

                case 5:
                    value = "May";
                    break;

                case 6:
                    value = "June";
                    break;

                case 7:
                    value = "July";
                    break;

                case 8:
                    value = "August";
                    break;

                case 9:
                    value = "September";
                    break;

                case 10:
                    value = "October";
                    break;

                case 11:
                    value = "November";
                    break;

                default:
                    value = "December";
                    break;
            }

            if (maxLength != 0)
            {
                value = value.Substring(0, maxLength);
            }

            if (toLowerCase)
            {
                value = value.ToLower();
            }

            return value;
        }
    }
}
