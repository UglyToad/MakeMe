namespace UglyToad.MakeMe.Specification.Date
{
    using System;

    /// <summary>
    /// Specification for generating <see cref="DateTime"/>.
    /// </summary>
    public class DateSpecification : ISpecification<DateTime>
    {
        internal const int MaxMonth = 12;
        internal const int MaxDay = 31;
        internal const int MaxHour = 23;
        internal const int MaxMinute = 59;
        internal const int MaxSecond = 59;
        internal const int MaxMillisecond = 999;

        internal bool IncludeTime { get; set; } = true;

        internal int[] Year { get; } = {DateTime.MinValue.Year, DateTime.MaxValue.Year};
        internal int[] Month { get; } = {1, MaxMonth};
        internal int[] Day { get; } = {1, MaxDay};
        internal int[] Hour { get; } = {0, MaxHour};
        internal int[] Minute { get; } = {0, MaxMinute};
        internal int[] Second { get; } = {0, MaxSecond};
        internal int[] Millisecond { get; } = {0, MaxMillisecond};

        private void SetUsingDate(DateTime dateTime, bool isFrom)
        {
            int index = isFrom ? 0 : 1;

            Year[index] = dateTime.Year;
            Month[index] = dateTime.Month;
            Day[index] = dateTime.Day;

            Hour[index] = dateTime.Hour;
            Minute[index] = dateTime.Minute;
            Second[index] = dateTime.Second;
            Millisecond[index] = dateTime.Millisecond;
        }

        /// <summary>
        /// Specifies whether to include time in the result <see cref="DateTime"/>.
        /// Default true.
        /// If set false results will have 00:00:00 for time part.
        /// </summary>
        /// <param name="include">True to include time part.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification IncludeTimePart(bool include)
        {
            IncludeTime = include;
            return this;
        }

        /// <summary>
        /// Generated dates will be after or on the current date and time (UTC).
        /// </summary>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromToday()
        {
            FromDate(DateTime.UtcNow);
            return this;
        }

        /// <summary>
        /// All generated dates will be in the specified year.
        /// </summary>
        /// <param name="year">The year to use.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification InYear(int year)
        {
            FromYear(year);
            ToYear(year);
            return this;
        }

        /// <summary>
        /// All generated dates will be in the specified month (but year can vary unless set elsewhere).
        /// </summary>
        /// <param name="month">The month to use.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification InMonth(int month)
        {
            FromMonth(month);
            ToMonth(month);
            return this;
        }

        /// <summary>
        /// All generated dates will be in the specified day (but year and month can vary unless previously set).
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public DateSpecification InDay(int day)
        {
            FromDay(day);
            ToDay(day);
            return this;
        }

        /// <summary>
        /// Generate data after or on this date.
        /// </summary>
        /// <param name="dateTime">The lower bound of date.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromDate(DateTime dateTime)
        {
            SetUsingDate(dateTime, true);
            return this;
        }

        /// <summary>
        /// Generate date before or on this date.
        /// </summary>
        /// <param name="dateTime">The upper bound of date.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToDate(DateTime dateTime)
        {
            SetUsingDate(dateTime, false);
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the year.
        /// </summary>
        /// <param name="year">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromYear(int year)
        {
            Year[0] = year;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the year.
        /// </summary>
        /// <param name="year">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToYear(int year)
        {
            Year[1] = year;
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the month.
        /// </summary>
        /// <param name="month">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromMonth(int month)
        {
            Month[0] = month;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the month.
        /// </summary>
        /// <param name="month">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToMonth(int month)
        {
            Month[1] = month;
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the day.
        /// </summary>
        /// <param name="day">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromDay(int day)
        {
            Day[0] = day;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the day.
        /// </summary>
        /// <param name="day">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToDay(int day)
        {
            Day[1] = day;
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the hour.
        /// </summary>
        /// <param name="hour">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromHour(int hour)
        {
            Hour[0] = hour;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the hour.
        /// </summary>
        /// <param name="hour">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToHour(int hour)
        {
            Hour[1] = hour;
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the minute.
        /// </summary>
        /// <param name="minute">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromMinute(int minute)
        {
            Minute[0] = minute;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the minute.
        /// </summary>
        /// <param name="minute">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToMinute(int minute)
        {
            Minute[1] = minute;
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the second.
        /// </summary>
        /// <param name="second">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromSecond(int second)
        {
            Second[0] = second;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the second.
        /// </summary>
        /// <param name="second">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToSecond(int second)
        {
            Second[1] = second;
            return this;
        }

        /// <summary>
        /// Sets the lower bound on the millisecond.
        /// </summary>
        /// <param name="millisecond">The lower bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification FromMillisecond(int millisecond)
        {
            Millisecond[0] = millisecond;
            return this;
        }

        /// <summary>
        /// Sets the upper bound on the millisecond.
        /// </summary>
        /// <param name="millisecond">The upper bound.</param>
        /// <returns>A <see cref="DateSpecification"/>.</returns>
        public DateSpecification ToMillisecond(int millisecond)
        {
            Millisecond[1] = millisecond;
            return this;
        }
    }
}
