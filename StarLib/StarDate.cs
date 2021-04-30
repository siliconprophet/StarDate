using System;
using System.Numerics;

namespace StarLib
{
    public struct StarDate
    {
        //time period data
        public const int TicksPerMillisecond = 10000;
        public const int TicksPerSecond = TicksPerMillisecond * 1000;
        public const long TicksPerMinute = TicksPerSecond * 60;
        public const long TicksPerHour = TicksPerMinute * 60;
        public const long TicksPerDay = TicksPerHour * 24;
        public const int DaysPerWeek = 7;
        public const long TicksPerWeek = TicksPerDay * DaysPerWeek;
        public const int DaysPerMonth = 4 * DaysPerWeek;
        public const long TicksPerMonth = TicksPerDay * DaysPerMonth;
        public const int DaysPerYear = DaysPerMonth * 13;
        public const int DaysPer7Years = DaysPerYear * 7 + DaysPerWeek;
        public const int DaysPerLeapYear = DaysPerYear + DaysPerWeek;
        public const int DaysPer45Years = DaysPer7Years * 5 + DaysPerWeek;
        public const int DaysPerDoubleLeapYear = DaysPerLeapYear + DaysPerWeek;
        public const int DaysPer140Years = DaysPer45Years * 4 + DaysPerWeek;
        public const int DaysPerTripleLeapYear = DaysPerDoubleLeapYear + DaysPerWeek;
        public const int DaysPer1400Years = DaysPer140Years * 10 + DaysPerWeek;
        public const int DaysPerQuadrupleLeapYear = DaysPerTripleLeapYear + DaysPerWeek;

        //struct data
        private BigInteger internalTicks;
        private StarZone _timeZone;

        //Leap Year Calculations
        public static bool isLeap(long year)
        {
            return year % 7 == 0;
        }
    }
}
