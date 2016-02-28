namespace UglyToad.MakeMe.Makers
{
    using System;
    using Specification.Date;

    internal class DateMaker : Maker<DateTime>
    {
        private readonly DateSpecification specification;

        public DateMaker(DateSpecification specification, Random random)
            : base(specification, random)
        {
            this.specification = specification;
        }

        public override DateTime Make()
        {
            var thisYear = GenerateYear();

            var thisMonth = GenerateMonth();

            var thisDay = GenerateDay(thisYear, thisMonth);

            var thisHour = GenerateHour();

            var thisMinute = GenerateMinute();

            var thisSecond = GenerateSecond();

            var thisMillisecond = GenerateMillisecond();

            if (specification.IncludeTime)
            {
                return new DateTime(thisYear, thisMonth, thisDay, thisHour, thisMinute, thisSecond, thisMillisecond);
            }

            return new DateTime(thisYear, thisMonth, thisDay);
        }

        private int GenerateYear()
        {
            if (specification.Year[0] < DateTime.MinValue.Year)
            {
                specification.Year[0] = DateTime.MinValue.Year;
            }
            if (specification.Year[1] > DateTime.MaxValue.Year)
            {
                specification.Year[1] = DateTime.MaxValue.Year;
            }

            ProtectLowerBound(specification.Year);

            return Random.Next(specification.Year[0], specification.Year[1]);
        }

        private int GenerateMonth()
        {
            if (specification.Month[0] < 1)
            {
                specification.Month[0] = 1;
            }
            if (specification.Month[1] > DateSpecification.MaxMonth)
            {
                specification.Month[1] = DateSpecification.MaxMonth;
            }

            ProtectLowerBound(specification.Month);

            return Random.Next(specification.Month[0], specification.Month[1]);
        }

        private int GenerateDay(int year, int month)
        {
            var maxDaysThisMonth = DateTime.DaysInMonth(year, month);

            if (specification.Day[0] < 1)
            {
                specification.Day[0] = 1;
            }
            if (specification.Day[1] > maxDaysThisMonth)
            {
                specification.Day[1] = maxDaysThisMonth;
            }

            ProtectLowerBound(specification.Day);

            return Random.Next(specification.Day[0], specification.Day[1]);
        }

        private int GenerateHour()
        {
            if (specification.Hour[0] < 0)
            {
                specification.Hour[0] = 0;
            }
            if (specification.Hour[1] > DateSpecification.MaxHour)
            {
                specification.Hour[1] = DateSpecification.MaxHour;
            }

            ProtectLowerBound(specification.Hour);

            return Random.Next(specification.Hour[0], specification.Hour[1]);
        }

        private int GenerateMinute()
        {
            if (specification.Minute[0] < 0)
            {
                specification.Minute[0] = 0;
            }
            if (specification.Minute[1] > DateSpecification.MaxMinute)
            {
                specification.Minute[1] = DateSpecification.MaxMinute;
            }

            ProtectLowerBound(specification.Minute);

            return Random.Next(specification.Minute[0], specification.Minute[1]);
        }

        private int GenerateSecond()
        {
            if (specification.Second[0] < 0)
            {
                specification.Second[0] = 0;
            }
            if (specification.Second[1] > DateSpecification.MaxSecond)
            {
                specification.Second[1] = DateSpecification.MaxSecond;
            }

            ProtectLowerBound(specification.Second);

            return Random.Next(specification.Second[0], specification.Second[1]);
        }

        private int GenerateMillisecond()
        {
            if (specification.Millisecond[0] < 0)
            {
                specification.Millisecond[0] = 0;
            }
            if (specification.Millisecond[1] > DateSpecification.MaxMillisecond)
            {
                specification.Millisecond[1] = DateSpecification.MaxMillisecond;
            }

            ProtectLowerBound(specification.Millisecond);

            return Random.Next(specification.Millisecond[0], specification.Millisecond[1]);
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