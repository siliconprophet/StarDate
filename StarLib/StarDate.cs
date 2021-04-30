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
        public const int DaysPerSevenYears = DaysPerYear * 7 + DaysPerWeek; 


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
