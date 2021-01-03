using System;
using System.Collections.Generic;
using System.Text;

namespace Extendy.DateTimes
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines whether or not the input date is the same year, month, and day as the current day
        /// </summary>
        /// <returns>Whether or not the date is the current date</returns>
        public static bool IsToday(this DateTime inputDate)
        {
            return DateTime.Today.Year == inputDate.Year && DateTime.Today.DayOfYear == inputDate.DayOfYear;
        }

        /// <summary>
        /// Determines whether or not the input date is the same year, month, and day as the current UTC day
        /// </summary>
        /// <returns>Whether or not the date is the current UTC date</returns>
        public static bool IsTodayUtc(this DateTime inputDateUtc)
        {
            return DateTime.UtcNow.Year == inputDateUtc.Year && DateTime.UtcNow.DayOfYear == inputDateUtc.DayOfYear;
        }

        /// <summary>
        /// Determines whether or not the input date is the same year, month, and day as the other date
        /// </summary>
        /// <param name="otherDate">The date to compare the current instance to</param>
        /// <returns>Whether or not another date is the same as the current instance</returns>
        public static bool IsSameDay(this DateTime inputDate, DateTime otherDate)
        {
            return inputDate.Year == otherDate.Year && inputDate.DayOfYear == otherDate.DayOfYear;
        }
    }
}
