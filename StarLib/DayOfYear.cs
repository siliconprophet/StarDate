using System;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace StarLib
{
    public struct DayOfYear : IComparable<DayOfYear>, IEquatable<DayOfYear>, IComparable, IFormattable, IConvertible
    {
        private int totalDays;
        //private int /*weekOfYear*/;

        //private string daySymbol;
        public static readonly string[] MonthSymbols = new String[] { "♐︎", "♑︎", "♒︎", "♓︎", "♈︎", "♉︎",
                                                            "♊︎", "♋︎", "♌︎", "♍︎", "♎︎", "♏︎", "⛎", "🕎"}; // month names
        public static readonly string[] DaySymbols = new String[] { "☉", "☾", "火", "☿", "♃", "金", "♄" };// day names
        private const int Min = 1;
        private const int Max = 378;

        public DayOfYear(int day)
        {
            if (day > Max)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (day < Min)
            {
                throw new ArgumentOutOfRangeException();
            }
            totalDays = day;
        }



        public DayOfYear(int month, int day)
        {
            if (month > 14)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (month < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (day > 28)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (day < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            month--;
            month *= 28;
            day += month;
            if (day > Max)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (day < Min)
            {
                throw new ArgumentOutOfRangeException();
            }
            totalDays = day;
        }

        public DayOfYear(long utcTicks, DateTimeKind utc) : this()
        {
        }

        public DayOfYear(BigInteger resultTicks, DateTimeKind utc) : this()
        {
        }

        public DayOfYear(object p, DateTimeKind unspecified) : this()
        {
        }

        // Returns the month part of this StarDate. The returned value is an
        // integer between 1 and 12.
        //
        public int Month
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 1 && Contract.Result<int>() <= 14);
                return (totalDays / 28) + 1;
            }
        }

        // Returns the week-of-Year part of this StarDate. The returned value
        // is an integer between 1 and 54.
        //

        public int WeekOfYear
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 1 && Contract.Result<int>() <= 54);
                return (totalDays / 7) + 1;
            }

            internal set
            {
                Contract.Ensures(value >= 1 && value <= (54));
                int diff = value - this.WeekOfYear;
                this = this.AddWeeks(diff);
            }
        }

        // Returns the day-of-Year part of this StarDate. The returned value
        // is an integer between 1 and 378.
        //

        public int DayOfYearInt
        {
            get => this.totalDays;
            set => this.totalDays = value;
        }

        // Returns the day-of-month part of this StarDate. The returned
        // value is an integer between 1 and 28.
        //

        public int Day
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 1);
                Contract.Ensures(Contract.Result<int>() <= 28);
                return totalDays % 28;
            }
        }

        // Returns the day-of-week part of this StarDate. The returned value
        // is an integer between 0 and 6, where 0 indicates Sunday, 1 indicates
        // Monday, 2 indicates Tuesday, 3 indicates Wednesday, 4 indicates
        // Thursday, 5 indicates Friday, and 6 indicates Saturday.
        // Based on localization it prints as a day of the week
        //

        public DayOfWeek DayOfWeek
        {
            get
            {
                Contract.Ensures(Contract.Result<DayOfWeek>() >= DayOfWeek.Sunday);
                Contract.Ensures(Contract.Result<DayOfWeek>() <= DayOfWeek.Saturday);
                return (DayOfWeek)(totalDays % 7);
            }
        }

        public string DaySymbol => GetDaySymbol(DayOfWeek);

        public string MonthSymbol => MonthSymbols[Month];

        internal string GetDaySymbol(DayOfWeek i)
        {
            return DaySymbols[(int)i];
        }

        //public bool DaySymbol { get; internal set; }

        public int CompareTo(object obj)
        {
            return totalDays.CompareTo(obj);
        }

        public int CompareTo(DayOfYear other)
        {
            return totalDays.CompareTo(other.totalDays);
        }

        public bool Equals(DayOfYear other)
        {
            return totalDays == other.totalDays;
        }

        public static DayOfYear operator ++(DayOfYear y)
        {
            y.totalDays++;
            return y;
        }

        public static DayOfYear operator --(DayOfYear y)
        {
            y.totalDays--;
            return y;
        }

        public static DayOfYear operator +(DayOfYear y, int i)
        {
            y.totalDays += i;
            return y;
        }

        public static DayOfYear operator -(DayOfYear y, int i)
        {
            y.totalDays -= i;
            return y;
        }

        public static bool operator ==(DayOfYear y1, DayOfYear y2)
        {
            return y1.Equals(y2);
        }

        public static bool operator !=(DayOfYear y1, DayOfYear y2)
        {
            return !y1.Equals(y2);
        }

        public static bool operator >=(DayOfYear y1, DayOfYear y2)
        {
            return y1.CompareTo(y2) != -1;
        }

        public static bool operator <=(DayOfYear y1, DayOfYear y2)
        {
            return y1.CompareTo(y2) != 1;
        }

        public static bool operator <(DayOfYear y1, DayOfYear y2)
        {
            return y1.CompareTo(y2) == -1;
        }

        public static bool operator >(DayOfYear y1, DayOfYear y2)
        {
            return y1.CompareTo(y2) == 1;
        }

        public string Holiday => DayOfYear.GetHoliday(this);

        public int TotalDays { get => totalDays; set => totalDays = value; }
        public static DayOfYear MinValue { get; internal set; }

        //private long ticks;

        public long GetTicks()
        {
            throw new NotImplementedException();
        }

        internal void SetTicks(long value)
        {
            throw new NotImplementedException();
        }

        public static long MinTicks { get; internal set; }
        public static long MaxTicks { get; internal set; }
        public static long MinOffset { get; internal set; }
        public static long MaxOffset { get; internal set; }
        public static BigInteger TicksPerDay { get; internal set; }
        public static DayOfYear Now { get; internal set; }
        public static double TicksPerSecond { get; internal set; }
        public static DayOfYear UtcNow { get; internal set; }

        //public static object UtcNow { get; internal set; }

        private static string GetHoliday(DayOfYear dayOfYear)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.ToString(StarCulture.CurrentCulture);
        }

        private string ToString(StarCulture currentCulture)
        {
            return ToString(currentCulture, "M");
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                return ToString();
            }
            return ToString(format);
        }

        public string ToString(string format)
        {
            return this.ToString(StarCulture.CurrentCulture, format);
        }

        private string ToString(StarCulture local, string format)
        {
            return local.DayOfYearString(this, format);
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
            return (byte)TotalDays;
        }

        public char ToChar(IFormatProvider provider)
        {
            return (char)TotalDays;
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return TotalDays;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return TotalDays;
        }

        public int ToInt16(IFormatProvider provider)
        {
            return TotalDays;
        }

        public int ToInt32(IFormatProvider provider)
        {
            return TotalDays;
        }

        public long ToInt64(IFormatProvider provider)
        {
            return TotalDays;
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return (sbyte)TotalDays;
        }

        public float ToSingle(IFormatProvider provider)
        {
            return TotalDays;
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt16(IFormatProvider provider)
        {
            return (uint)TotalDays;
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return (uint)TotalDays;
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)TotalDays;
        }

        public static implicit operator DayOfYear(int v)
        {
            return new DayOfYear(v);
        }

        public static implicit operator int(DayOfYear v)
        {
            return v.totalDays;
        }

        public static implicit operator string(DayOfYear v)
        {
            return v.ToString();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)totalDays).ToInt16(provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)totalDays).ToUInt16(provider);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal static DayOfYear SpecifyKind(DayOfYear parsedDate, DateTimeKind local)
        {
            throw new NotImplementedException();
        }

        internal DayOfYear AddTicks(long v)
        {
            throw new NotImplementedException();
        }

        public string MonthName => StarCulture.CurrentCulture.GetMonthName(Month);



        private DayOfYear AddWeeks(int diff)
        {
            return this.AddDays(diff * 7);
        }

        private DayOfYear AddDays(int v)
        {
            DayOfYear d = this;
            d.TotalDays += v;
            return d;
        }
    }
}