namespace UglyToad.MakeMe.Specification.Date
{
    using System;

    public class DateSpecification : ISpecification<DateTime>
    {
        public const int MaxMonth = 12;
        public const int MaxDay = 31;
        public const int MaxHour = 23;
        public const int MaxMinute = 59;
        public const int MaxSecond = 59;
        public const int MaxMillisecond = 999;

        public bool IncludeTime { get; set; } = true;

        public int[] Year { get; } = {DateTime.MinValue.Year, DateTime.MaxValue.Year};
        public int[] Month { get; } = {1, MaxMonth};
        public int[] Day { get; } = {1, MaxDay};
        public int[] Hour { get; } = {0, MaxHour};
        public int[] Minute { get; } = {0, MaxMinute};
        public int[] Second { get; } = {0, MaxSecond};
        public int[] Millisecond { get; } = {0, MaxMillisecond};

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

        public DateSpecification IncludeTimePart(bool include)
        {
            IncludeTime = include;
            return this;
        }

        public DateSpecification FromToday()
        {
            FromDate(DateTime.UtcNow);
            return this;
        }

        public DateSpecification InYear(int year)
        {
            FromYear(year);
            ToYear(year);
            return this;
        }

        public DateSpecification InMonth(int month)
        {
            FromMonth(month);
            ToMonth(month);
            return this;
        }

        public DateSpecification InDay(int day)
        {
            FromDay(day);
            ToDay(day);
            return this;
        }

        public DateSpecification InHour(int hour)
        {
            FromHour(hour);
            ToHour(hour);
            return this;
        }

        public DateSpecification InMinute(int minute)
        {
            FromMinute(minute);
            ToMinute(minute);
            return this;
        }

        public DateSpecification InSecond(int second)
        {
            FromSecond(second);
            ToSecond(second);
            return this;
        }

        public DateSpecification InMillisecond(int millisecond)
        {
            FromMillisecond(millisecond);
            ToMillisecond(millisecond);
            return this;
        }

        public DateSpecification FromDate(DateTime dateTime)
        {
            SetUsingDate(dateTime, true);
            return this;
        }

        public DateSpecification ToDate(DateTime dateTime)
        {
            SetUsingDate(dateTime, false);
            return this;
        }

        public DateSpecification FromYear(int year)
        {
            Year[0] = year;
            return this;
        }

        public DateSpecification ToYear(int year)
        {
            Year[1] = year;
            return this;
        }

        public DateSpecification FromMonth(int month)
        {
            Month[0] = month;
            return this;
        }

        public DateSpecification ToMonth(int month)
        {
            Month[1] = month;
            return this;
        }

        public DateSpecification FromDay(int day)
        {
            Day[0] = day;
            return this;
        }

        public DateSpecification ToDay(int day)
        {
            Day[1] = day;
            return this;
        }

        public DateSpecification FromHour(int hour)
        {
            Hour[0] = hour;
            return this;
        }

        public DateSpecification ToHour(int hour)
        {
            Hour[1] = hour;
            return this;
        }

        public DateSpecification FromMinute(int minute)
        {
            Minute[0] = minute;
            return this;
        }

        public DateSpecification ToMinute(int minute)
        {
            Minute[1] = minute;
            return this;
        }

        public DateSpecification FromSecond(int second)
        {
            Second[0] = second;
            return this;
        }

        public DateSpecification ToSecond(int second)
        {
            Second[1] = second;
            return this;
        }

        public DateSpecification FromMillisecond(int millisecond)
        {
            Millisecond[0] = millisecond;
            return this;
        }

        public DateSpecification ToMillisecond(int millisecond)
        {
            Millisecond[1] = millisecond;
            return this;
        }
    }
}
