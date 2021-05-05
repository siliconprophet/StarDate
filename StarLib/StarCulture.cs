using System;

namespace StarLib
{
    internal class StarCulture
    {
        public static StarCulture CurrentCulture;

        public bool ThirtyHour { get; internal set; }

        internal string DayOfYearString(DayOfYear dayOfYear, string format)
        {
            throw new NotImplementedException();
        }

        internal string GetMonthName(int month)
        {
            throw new NotImplementedException();
        }

        internal static StarCulture GetInstance(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        internal string TimeOfDayString(TimeOfDay timeOfDay, string format)
        {
            throw new NotImplementedException();
        }
    }
}