using System;
using System.Net.NetworkInformation;

namespace StarLib
{
    public class StarZone
    {
        public static StarZone UTC
        {
            get
            {
                return new StarZone();
            }
        }
        private ZoneInternal zone = ZoneInternal.UTC;
        public TimeZoneInfo TimeZoneInfo
        {
            get
            {
                if (zone == ZoneInternal.UTC)
                {
                    return TimeZoneInfo.Utc;
                }
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

    internal enum ZoneInternal
    {
        UTC
    }
}