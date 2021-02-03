using System;
using System.Collections.Generic;
using Extendy.DateTimes;
using Xunit;

namespace ExtendyTests.DateTimes
{
    public class DateTimeExtensionsTests
    {
        [Theory]
        [MemberData(nameof(GetTodayDates))]
        public void IsTodayTest(bool expectedResult, DateTime inputDate)
        {
            Assert.Equal(expectedResult, inputDate.IsToday());
        }

        [Theory]
        [MemberData(nameof(GetTodayUtcDates))]
        public void IsTodayUtcTest(bool expectedResult, DateTime inputDate)
        {
            Assert.Equal(expectedResult, inputDate.IsTodayUtc());
        }

        [Theory]
        [MemberData(nameof(GetSameDayDates))]
        public void IsSameDayTest(bool expectedResult, DateTime inputDate1, DateTime inputDate2)
        {
            Assert.Equal(expectedResult, inputDate1.IsSameDay(inputDate2));
        }

        public static List<object[]> GetTodayDates()
        {
            return new List<object[]>
            {
                new object[] { true, DateTime.Today },
                new object[] { true, DateTime.Today.AddHours(23.999999) },
                new object[] { false, DateTime.Today.AddMilliseconds(-1) },
                new object[] { false, DateTime.Today.AddDays(1) },
                new object[] { false, DateTime.Today.AddDays(-1) },
                new object[] { false, DateTime.Today.AddMonths(1) },
                new object[] { false, DateTime.Today.AddMonths(-1) },
                new object[] { false, DateTime.Today.AddYears(1) },
                new object[] { false, DateTime.Today.AddYears(-1) }
            };
        }

        public static List<object[]> GetTodayUtcDates()
        {
            DateTime utcToday = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            return new List<object[]>
            {
                new object[] { true, utcToday },
                new object[] { true, utcToday.AddHours(23.999999) },
                new object[] { false, utcToday.AddMilliseconds(-1) },
                new object[] { false, utcToday.AddDays(1) },
                new object[] { false, utcToday.AddDays(-1) },
                new object[] { false, utcToday.AddMonths(1) },
                new object[] { false, utcToday.AddMonths(-1) },
                new object[] { false, utcToday.AddYears(1) },
                new object[] { false, utcToday.AddYears(-1) }
            };
        }

        public static List<object[]> GetSameDayDates()
        {
            return new List<object[]>
            {
                new object[] { true, new DateTime(2020, 12, 25), new DateTime(2020, 12, 25) },
                new object[] { false, new DateTime(2020, 12, 25), new DateTime(2021, 12, 25) },
                new object[] { false, new DateTime(2020, 12, 25), new DateTime(2020, 11, 25) },
                new object[] { false, new DateTime(2020, 12, 25), new DateTime(2020, 12, 24) },
                new object[] { false, new DateTime(2021, 12, 25), new DateTime(2020, 12, 25) },
                new object[] { false, new DateTime(2020, 11, 25), new DateTime(2020, 12, 25) },
                new object[] { false, new DateTime(2020, 12, 24), new DateTime(2020, 12, 25) },
                new object[] { true, new DateTime(2020, 12, 25), new DateTime(2020, 12, 25, 1, 0, 0) },
                new object[] { true, new DateTime(2020, 12, 25), new DateTime(2020, 12, 25, 0, 1, 0) },
                new object[] { true, new DateTime(2020, 12, 25), new DateTime(2020, 12, 25, 0, 0, 1) },
                new object[] { true, new DateTime(2020, 12, 25), new DateTime(2020, 12, 25, 0, 0, 0, 1) },
                new object[] { true, new DateTime(2020, 12, 25, 1, 0, 0), new DateTime(2020, 12, 25) },
                new object[] { true, new DateTime(2020, 12, 25, 0, 1, 0), new DateTime(2020, 12, 25) },
                new object[] { true, new DateTime(2020, 12, 25, 0, 0, 1), new DateTime(2020, 12, 25) },
                new object[] { true, new DateTime(2020, 12, 25, 0, 0, 0, 1), new DateTime(2020, 12, 25) },
                new object[] { true, new DateTime(2020, 12, 25, 0, 0, 1), new DateTime(2020, 12, 25, 23, 59, 59, 999) }
            };
        }
    }
}
