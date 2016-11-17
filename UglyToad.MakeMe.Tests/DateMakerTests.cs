namespace UglyToad.MakeMe.Tests
{
    using System;
    using System.Linq;
    using Xunit;

    public class DateMakerTests
    {
        private static readonly int ThisManyTimes = 5200;

        [Fact]
        public void DateMakerUnrestricted_ReturnsSomeDates()
        {
            var dates = MakeFactory.Make(A.Date()).GenerateSeries(ThisManyTimes);

            Assert.Equal(ThisManyTimes, dates.Count());
        }

        [Fact]
        public void DateMaker_DateOnly_ReturnsDates()
        {
            var dates = MakeFactory.Make(A.Date().IncludeTimePart(false)).GenerateSeries(ThisManyTimes);

            Assert.Equal(0, dates.Count(d => d.Hour != 0 || d.Minute != 0 || d.Second != 0 || d.Millisecond != 0));
        }

        [Fact]
        public void DateMaker_Seeded_ReturnsTheSameSeries()
        {
            var datesFirst = MakeFactory.Make(A.Date(), 52).GenerateSeries(ThisManyTimes);

            var datesSecond = MakeFactory.Make(A.Date(), 52).GenerateSeries(ThisManyTimes);

            Assert.Equal(datesFirst, datesSecond);
        }

        [Fact]
        public void DateMaker_LimitedToFirstDay_ReturnsCorrectDates()
        {
            var dates = MakeFactory.Make(A.Date().ToDay(1)).GenerateSeries(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Day > 1));
        }

        [Fact]
        public void DateMaker_LimitedToIncorrectDay_ReturnsCorrectDates()
        {
            var dates = MakeFactory.Make(A.Date().ToDay(-1)).GenerateSeries(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Day > 1));
        }

        [Fact]
        public void DateMaker_LimitedToYearAndHour_ReturnsCorrectDates()
        {
            var dates =
                MakeFactory.Make(A.Date().FromYear(2001).ToYear(2001).FromHour(2).ToHour(3))
                    .GenerateSeries(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001 || d.Hour < 2 || d.Hour > 3));
        }

        [Fact]
        public void DateMaker_LimitedToYear_ReturnsCorrectDates()
        {
            var dates = MakeFactory.Make(A.Date().InYear(2001)).GenerateSeries(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001));
        }

        [Fact]
        public void DateMaker_LastLimitWins_ReturnsCorrectDates()
        {
            var dates = MakeFactory.Make(A.Date().InYear(2003).InYear(2001)).GenerateSeries(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001));
        }

        [Fact]
        public void DateMaker_LimitByDateTime_ReturnsCorrectDates()
        {
            var dates = MakeFactory.Make(A.Date()
                .FromDate(new DateTime(2001, 01, 12))
                .ToDate(new DateTime(2001, 01, 13))).GenerateSeries(ThisManyTimes);

            Assert.Empty(dates.Where(d => d.Year != 2001 || d.Month != 1 || d.Day < 12 || d.Day > 13));
        }
    }
}