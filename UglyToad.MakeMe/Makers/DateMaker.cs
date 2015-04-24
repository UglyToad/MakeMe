namespace UglyToad.MakeMe.Makers
{
    using System;
    using System.Collections.Generic;

    public class DateMaker : IMake<DateTime>
    {
        private const int MaxMonth = 12;
        private const int MaxDay = 31;
        private const int MaxHour = 23;
        private const int MaxMinute = 59;
        private const int MaxSecond = 59;
        private const int MaxMillisecond = 999;

        private readonly bool includeTime;

        private Random random;

        private int[] year = { DateTime.MinValue.Year, DateTime.MaxValue.Year };
        private int[] month = { 1, MaxMonth };
        private int[] day = { 1, MaxDay };
        private int[] hour = { 0, MaxHour };
        private int[] minute = { 0, MaxMinute };
        private int[] second = { 0, MaxSecond };
        private int[] millisecond = { 0, MaxMillisecond };

        public DateMaker(bool includeTime)
        {
            this.includeTime = includeTime;
            this.random = new Random();
        }

        private void SetUsingDate(DateTime dateTime, bool isFrom)
        {
            int index = isFrom ? 0 : 1;

            year[index] = dateTime.Year;
            month[index] = dateTime.Month;
            day[index] = dateTime.Day;

            hour[index] = dateTime.Hour;
            minute[index] = dateTime.Minute;
            second[index] = dateTime.Second;
            millisecond[index] = dateTime.Millisecond;
        }

        public DateMaker FromToday()
        {
            FromDate(DateTime.UtcNow);
            return this;
        }

        public DateMaker Year(int year)
        {
            FromYear(year);
            ToYear(year);
            return this;
        }

        public DateMaker Month(int month)
        {
            FromMonth(month);
            ToMonth(month);
            return this;
        }

        public DateMaker Day(int day)
        {
            FromDay(day);
            ToDay(day);
            return this;
        }

        public DateMaker Hour(int hour)
        {
            FromHour(hour);
            ToHour(hour);
            return this;
        }

        public DateMaker Minute(int minute)
        {
            FromMinute(minute);
            ToMinute(minute);
            return this;
        }

        public DateMaker Second(int second)
        {
            FromSecond(second);
            ToSecond(second);
            return this;
        }

        public DateMaker Millisecond(int millisecond)
        {
            FromMillisecond(millisecond);
            ToMillisecond(millisecond);
            return this;
        }

        public DateMaker GenerateUsingSeed(int seed)
        {
            random = new Random(seed);
            return this;
        }

        public DateMaker FromDate(DateTime dateTime)
        {
            SetUsingDate(dateTime, true);
            return this;
        }

        public DateMaker ToDate(DateTime dateTime)
        {
            SetUsingDate(dateTime, false);
            return this;
        }

        public DateMaker FromYear(int year)
        {
            this.year[0] = year;
            return this;
        }

        public DateMaker ToYear(int year)
        {
            this.year[1] = year;
            return this;
        }

        public DateMaker FromMonth(int month)
        {
            this.month[0] = month;
            return this;
        }

        public DateMaker ToMonth(int month)
        {
            this.month[1] = month;
            return this;
        }

        public DateMaker FromDay(int day)
        {
            this.day[0] = day;
            return this;
        }

        public DateMaker ToDay(int day)
        {
            this.day[1] = day;
            return this;
        }

        public DateMaker FromHour(int hour)
        {
            this.hour[0] = hour;
            return this;
        }

        public DateMaker ToHour(int hour)
        {
            this.hour[1] = hour;
            return this;
        }

        public DateMaker FromMinute(int minute)
        {
            this.minute[0] = minute;
            return this;
        }

        public DateMaker ToMinute(int minute)
        {
            this.minute[1] = minute;
            return this;
        }

        public DateMaker FromSecond(int second)
        {
            this.second[0] = second;
            return this;
        }

        public DateMaker ToSecond(int second)
        {
            this.second[1] = second;
            return this;
        }

        public DateMaker FromMillisecond(int millisecond)
        {
            this.millisecond[0] = millisecond;
            return this;
        }

        public DateMaker ToMillisecond(int millisecond)
        {
            this.millisecond[1] = millisecond;
            return this;
        }

        public DateTime Please()
        {
            int thisYear = GenerateYear();

            int thisMonth = GenerateMonth();

            int thisDay = GenerateDay(thisYear, thisMonth);

            int thisHour = GenerateHour();

            var thisMinute = GenerateMinute();

            int thisSecond = GenerateSecond();

            int thisMillisecond = GenerateMillisecond();

            if (includeTime)
            {
                return new DateTime(thisYear, thisMonth, thisDay, thisHour, thisMinute, thisSecond);
            }

            return new DateTime(thisYear, thisMonth, thisDay);
        }

        public IEnumerable<DateTime> ThisManyTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                yield return Please();
            }
        }
        
        private int GenerateYear()
        {
            if (this.year[0] < DateTime.MinValue.Year)
            {
                this.year[0] = DateTime.MinValue.Year;
            }
            if (this.year[1] > DateTime.MaxValue.Year)
            {
                this.year[1] = DateTime.MaxValue.Year;
            }

            ProtectLowerBound(this.year);

            return random.Next(this.year[0], this.year[1]);
        }

        private int GenerateMonth()
        {
            if (this.month[0] < 1)
            {
                this.month[0] = 1;
            }
            if (this.month[1] > MaxMonth)
            {
                this.month[1] = MaxMonth;
            }

            ProtectLowerBound(this.month);

            return random.Next(this.month[0], this.month[1]);
        }

        private int GenerateDay(int year, int month)
        {
            int maxDaysThisMonth = DateTime.DaysInMonth(year, month);

            if (this.day[0] < 1)
            {
                this.day[0] = 1;
            }
            if (this.day[1] > maxDaysThisMonth)
            {
                this.day[1] = maxDaysThisMonth;
            }

            ProtectLowerBound(this.day);

            return random.Next(this.day[0], this.day[1]);
        }

        private int GenerateHour()
        {
            if (this.hour[0] < 0)
            {
                this.hour[0] = 0;
            }
            if (this.hour[1] > MaxHour)
            {
                this.hour[1] = MaxHour;
            }

            ProtectLowerBound(this.hour);

            return random.Next(this.hour[0], this.hour[1]);
        }

        private int GenerateMinute()
        {
            if (this.minute[0] < 0)
            {
                this.minute[0] = 0;
            }
            if (this.minute[1] > MaxMinute)
            {
                this.minute[1] = MaxMinute;
            }

            ProtectLowerBound(this.minute);

            return random.Next(this.minute[0], this.minute[1]);
        }

        private int GenerateSecond()
        {
            if (this.second[0] < 0)
            {
                this.second[0] = 0;
            }
            if (this.second[1] > MaxSecond)
            {
                this.second[1] = MaxSecond;
            }

            ProtectLowerBound(this.second);

            return random.Next(this.second[0], this.second[1]);
        }

        private int GenerateMillisecond()
        {
            if (this.millisecond[0] < 0)
            {
                this.millisecond[0] = 0;
            }
            if (this.millisecond[1] > MaxMillisecond)
            {
                this.millisecond[1] = MaxMillisecond;
            }

            ProtectLowerBound(this.millisecond);

            return random.Next(this.millisecond[0], this.millisecond[1]);
        }

        private void ProtectLowerBound(int[] values)
        {
            if (values[1] < values[0])
            {
                values[1] = values[0];
            }
        }
    }
}