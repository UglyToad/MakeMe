namespace UglyToad.MakeMe.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class DateMakerTests
    {
        private static readonly int ThisManyTimes = 5200;

        [Fact]
        public void DateMakerUnrestricted_ReturnsSomeDates()
        {
            IEnumerable<DateTime> dates = MakeMeA.Date().ThisManyTimes(ThisManyTimes);

            Assert.Equal(ThisManyTimes, dates.Count());
        }

        [Fact]
        public void DateMaker_DateOnly_ReturnsDates()
        {
            IEnumerable<DateTime> dates = MakeMeA.Date(false).ThisManyTimes(ThisManyTimes);

            Assert.Equal(0, dates.Count(d => d.Hour != 0 || d.Minute != 0 || d.Second != 0 || d.Millisecond != 0));
        }

        [Fact]
        public void DateMaker_Seeded_ReturnsTheSameSeries()
        {
            IEnumerable<DateTime> datesFirst = MakeMeA.Date().GenerateUsingSeed(420).ThisManyTimes(ThisManyTimes);

            IEnumerable<DateTime> datesSecond = MakeMeA.Date().GenerateUsingSeed(420).ThisManyTimes(ThisManyTimes);

            Assert.Equal(datesFirst, datesSecond);
        }

        [Fact]
        public void DateMaker_LimitedToFirstDay_ReturnsCorrectDates()
        {
            var dates = MakeMeA.Date().ToDay(1).ThisManyTimes(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Day > 1));
        }

        [Fact]
        public void DateMaker_LimitedToIncorrectDay_ReturnsCorrectDates()
        {
            var dates = MakeMeA.Date().ToDay(-1).ThisManyTimes(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Day > 1));
        }

        [Fact]
        public void DateMaker_LimitedToYearAndHour_ReturnsCorrectDates()
        {
            var dates = MakeMeA.Date().FromYear(2001).ToYear(2001).FromHour(2).ToHour(3).ThisManyTimes(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001 || d.Hour < 2 || d.Hour > 3));
        }

        [Fact]
        public void DateMaker_LimitedToYear_ReturnsCorrectDates()
        {
            var dates = MakeMeA.Date().Year(2001).ThisManyTimes(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001));
        }

        [Fact]
        public void DateMaker_LastLimitWins_ReturnsCorrectDates()
        {
            var dates = MakeMeA.Date().Year(2003).Year(2001).ThisManyTimes(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001));
        }

        [Fact]
        public void DateMaker_LimitByDateTime_ReturnsCorrectDates()
        {
            var dates =
                MakeMeA.Date(false)
                    .FromDate(new DateTime(2001, 01, 12))
                    .ToDate(new DateTime(2001, 01, 13))
                    .ThisManyTimes(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001 || d.Month != 1 || d.Day < 12 || d.Day > 13));
        }
    }
}