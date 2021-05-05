//using StarLib.Parsing;
using System;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace StarLib
{
    public struct TimeOfDay : IComparable<TimeOfDay>, IEquatable<TimeOfDay>, IComparable, IFormattable, IConvertible
    {
        // Number of 100ns _ticks per time unit
        internal const int TicksPerMillisecond = 10000;
        internal const int TicksPerSecond = TicksPerMillisecond * 1000;
        internal const long TicksPerMinute = TicksPerSecond * 60;
        internal const long TicksPerHour = TicksPerMinute * 60;
        internal const long TicksPerDay = TicksPerHour * 24;
        // Number of milliseconds per time unit
        private const int MillisPerSecond = 1000;
        private const int MillisPerMinute = MillisPerSecond * 60;
        private const int MillisPerHour = MillisPerMinute * 60;
        private const int MillisPerDay = MillisPerHour * 24;
        //Max and Min Values
        private const long Max = StarDate.TicksPerDay;
        private const long Min = 0;
        private const long MaxMillis = Max / TicksPerMillisecond;


        //Data
        private long _ticks;

        public TimeOfDay(long ticks)
        {
            if (ticks > Max)
            {

            }
            else if (ticks < Min)
            {

            }
            _ticks = ticks;
        }

        internal static bool EnableAmPmParseAdjustment()
        {
            throw new NotImplementedException();
        }

        public TimeOfDay(BigInteger bigInteger) : this((long)bigInteger)
        {

        }

        public TimeOfDay(int hour) : this(hour, 0)
        {

        }

        public TimeOfDay(int hour, int min) : this(hour, min, 0)
        {

        }

        public TimeOfDay(int hour, int min, int sec) : this(hour, min, sec, 0)
        {

        }

        public TimeOfDay(int hour, int min, int sec, int mil) : this(hour, min, sec, mil, 0)
        {

        }

        public TimeOfDay(int hour, int min, int sec, int mil, int ticks) : this()
        {
            _ticks = hour * TicksPerHour + min * TicksPerMinute + sec * TicksPerSecond + mil * TicksPerMillisecond + ticks;
        }

        public TimeOfDay(long ticks, DateTimeKind utc) : this(ticks)
        {
        }

        public TimeOfDay(BigInteger bigInteger, DateTimeKind utc) : this(bigInteger)
        {
        }

        //public TimeOfDay(BigInteger resultTicks, DateTimeKind utc) : this()
        //{
        //}

        //public TimeOfDay(BigInteger resultTicks, DateTimeKind utc) : this()
        //{
        //}

        public long Ticks
        {
            get => _ticks;

            internal set => _ticks = value;
        }

        // Returns the hour part of this StarDate. The returned value is an
        // integer between 0 and 23.

        public int Hour
        {
            get
            {
                if (StarCulture.CurrentCulture.ThirtyHour)
                {
                    Contract.Ensures(Contract.Result<int>() >= 0);
                    Contract.Ensures(Contract.Result<int>() < 30);
                    int h = (int)(Ticks / TicksPerHour);
                    if (h < 6)
                    {
                        h += 24;
                    }
                    return h;
                }
                else
                {
                    Contract.Ensures(Contract.Result<int>() >= 0);
                    Contract.Ensures(Contract.Result<int>() < 24);
                    return (int)(Ticks / TicksPerHour);
                }
            }
            set
            {
                int h = value;
                int diff = h - this.Hour;
                this = AddHours(diff);
            }
        }


        // Returns the minute part of this StarDate. The returned value is
        // an integer between 0 and 59.
        //
        public int Minute
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                Contract.Ensures(Contract.Result<int>() < 60);
                return (int)((Ticks / TicksPerMinute) % 60);
            }
            set
            {
                int h = value;
                int diff = h - this.Minute;
                this = AddMinutes(diff);
            }
        }


        // Returns the second part of this StarDate. The returned value is
        // an integer between 0 and 59.
        //
        public int Second
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                Contract.Ensures(Contract.Result<int>() < 60);
                return (int)((Ticks / TicksPerSecond) % 60);
            }
            set
            {
                int diff = value - this.Second;
                this = AddSeconds(diff);
            }
        }


        // Returns the millisecond part of this StarDate. The returned value
        // is an integer between 0 and 999.
        //

        public int Millisecond
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                Contract.Ensures(Contract.Result<int>() < 1000);
                return (int)((Ticks / TicksPerMillisecond) % 1000);
            }
            set
            {
                int diff = value - this.Millisecond;
                this = AddMilliseconds(diff);
            }
        }


        // Returns Ticks of this stardate that are not in a full millisecond
        // integer between 1 and 10000.

        public int ExtraTicks
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                Contract.Ensures(Contract.Result<int>() < 10000);
                return (int)((Ticks % TicksPerMillisecond));
            }
            set
            {
                int diff = value - this.ExtraTicks;
                this.Ticks += diff;
            }
        }

        public static TimeOfDay MinValue { get; internal set; }
        public static long MaxOffset { get; internal set; }
        public static long MinOffset { get; internal set; }
        public static long MinTicks { get; internal set; }
        public static long MaxTicks { get; internal set; }
        public static TimeOfDay Now { get; internal set; }
        public static TimeOfDay UtcNow { get; internal set; }

        // Returns the StarDate resulting from adding a fractional number of
        // hours to this StarDate. The result is computed by rounding the
        // fractional number of hours given by value to the nearest
        // millisecond, and adding that interval to this StarDate. The
        // value argument is permitted to be negative.
        //
        public TimeOfDay AddHours(double value)
        {
            return Add(value, MillisPerHour);
        }

        // Returns the StarDate resulting from adding a fractional number of
        // minutes to this StarDate. The result is computed by rounding the
        // fractional number of minutes given by value to the nearest
        // millisecond, and adding that interval to this StarDate. The
        // value argument is permitted to be negative.
        //
        public TimeOfDay AddMinutes(double value)
        {
            return Add(value, MillisPerMinute);
        }

        // Returns the StarDate resulting from adding a fractional number of
        // seconds to this StarDate. The result is computed by rounding the
        // fractional number of seconds given by value to the nearest
        // millisecond, and adding that interval to this StarDate. The
        // value argument is permitted to be negative.
        //
        public TimeOfDay AddSeconds(double value)
        {
            return Add(value, MillisPerSecond);
        }

        // Returns the StarDate resulting from the given number of
        // milliseconds to this StarDate. The result is computed by rounding
        // the number of milliseconds given by value to the nearest integer,
        // and adding that interval to this StarDate. The value
        // argument is permitted to be negative.
        //
        public TimeOfDay AddMilliseconds(double value)
        {
            return Add(value, 1);
        }







        // Returns the StarDate resulting from adding the given number of
        // 100-nanosecond _ticks to this StarDate. The value argument
        // is permitted to be negative.
        //
        public TimeOfDay AddTicks(long value)
        {
            TimeOfDay t = this;
            t.Ticks += value;
            return t;
        }

        // Returns the StarDate resulting from adding a fractional number of
        // time units to this StarDate.
        private TimeOfDay Add(double value, int scale)
        {
            long millis = (long)(value * scale + (value >= 0 ? 0.5 : -0.5));
            //if (millis <= -MaxMillis || millis >= MaxMillis)
            //    throw new ArgumentOutOfRangeException(); //("value", ); //Environment.GetResourceString("ArgumentOutOfRange_AddValue"));
            return AddTicks(millis * TicksPerMillisecond);
        }

        private TimeOfDay Add(double value, long scale)
        {
            long millis = (long)(value * scale + (value >= 0 ? 0.5 : -0.5));
            if (millis <= -MaxMillis || millis >= MaxMillis)
                throw new ArgumentOutOfRangeException(); //("value", ); //Environment.GetResourceString("ArgumentOutOfRange_AddValue"));
            return AddTicks(millis * TicksPerMillisecond);
        }

        public static TimeOfDay operator -(TimeOfDay t1, TimeOfDay t2)
        {
            throw new NotImplementedException();
        }

        public static TimeOfDay operator +(TimeOfDay t1, TimeOfDay t2)
        {
            throw new NotImplementedException();
        }

        public static TimeOfDay operator +(TimeOfDay timeOfDay, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public static implicit operator string(TimeOfDay t)
        {
            return t.ToString();
        }


        public int CompareTo(object obj)
        {
            return Ticks.CompareTo(obj);
        }

        public int CompareTo(TimeOfDay other)
        {
            return Ticks.CompareTo(other.Ticks);
        }

        public bool Equals(TimeOfDay other)
        {
            return Ticks == other.Ticks;
        }

        public static TimeOfDay operator +(TimeOfDay y, int i)
        {
            y.Ticks += i;
            return y;
        }

        public static TimeOfDay operator -(TimeOfDay y, int i)
        {
            y.Ticks -= i;
            return y;
        }

        public static bool operator ==(TimeOfDay y1, TimeOfDay y2)
        {
            return y1.Equals(y2);
        }

        public static bool operator !=(TimeOfDay y1, TimeOfDay y2)
        {
            return !y1.Equals(y2);
        }

        public static bool operator >=(TimeOfDay y1, TimeOfDay y2)
        {
            return y1.CompareTo(y2) != -1;
        }

        public static bool operator <=(TimeOfDay y1, TimeOfDay y2)
        {
            return y1.CompareTo(y2) != 1;
        }

        public static bool operator <(TimeOfDay y1, TimeOfDay y2)
        {
            return y1.CompareTo(y2) == -1;
        }

        public static bool operator >(TimeOfDay y1, TimeOfDay y2)
        {
            return y1.CompareTo(y2) == 1;
        }

        public override string ToString()
        {
            return this.ToString(StarCulture.CurrentCulture);
        }

        private string ToString(StarCulture currentCulture)
        {
            return ToString(currentCulture, "L");
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                return ToString();
            }
            return ToString(format);
        }

        private string ToString(string format)
        {
            return this.ToString(StarCulture.CurrentCulture, format);
        }

        private string ToString(StarCulture currentCulture, string format)
        {
            return currentCulture.TimeOfDayString(this, format);
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(null, provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)Ticks;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal static TimeOfDay SpecifyKind(TimeOfDay parsedDate, DateTimeKind local)
        {
            throw new NotImplementedException();
        }
    }
}