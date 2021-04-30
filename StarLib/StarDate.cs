using System;
using System.Numerics;

namespace StarLib
{
    public struct StarDate
    {
        //time period data
        internal const int TicksPerMillisecond = 10000;
        internal const int TicksPerSecond = TicksPerMillisecond * 1000;
        internal const long TicksPerMinute = TicksPerSecond * 60;
        internal const long TicksPerHour = TicksPerMinute * 60;
        internal const long TicksPerDay = TicksPerHour * 24;
        internal const int DaysPerWeek = 7;
        internal const long TicksPerWeek = TicksPerDay * DaysPerWeek;
        internal const int DaysPerMonth = 4 * DaysPerWeek;
        internal const long TicksPerMonth = TicksPerDay * DaysPerMonth;

        //struct data
        private BigInteger internalTicks;
    }
}
