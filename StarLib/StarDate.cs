using System;
using System.Numerics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StarLib
{
    public struct StarDate : IComparable<StarDate>, IEquatable<StarDate>, IComparable, IFormattable, IConvertible, IComparable<DateTime>, IEquatable<DateTime>, IXmlSerializable
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
        public const int DaysPer35Years = DaysPer7Years * 5 + DaysPerWeek;
        public const int DaysPerDoubleLeapYear = DaysPerLeapYear + DaysPerWeek;
        public const int DaysPer140Years = DaysPer35Years * 4 + DaysPerWeek;
        public const int DaysPerTripleLeapYear = DaysPerDoubleLeapYear + DaysPerWeek;
        public const int DaysPer1400Years = DaysPer140Years * 10 + DaysPerWeek;
        public const int DaysPerQuadrupleLeapYear = DaysPerTripleLeapYear + DaysPerWeek;

        //struct data
        private Date _date;
        private TimeOfDay _time;
        private StarZone _timeZone;

        //Leap Year Calculations
        public static bool isLeap(long year)
        {
            return year % 7 == 0;
        }

        public int CompareTo(DateTime other)
        {
            return this.CompareTo(new StarDate(other));
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(StarDate other)
        {
            return this.Ticks.CompareTo(other.Ticks);
        }

        public bool Equals(DateTime other)
        {
            return this.CompareTo(other) == 0;
        }

        public bool Equals(StarDate other)
        {
            return this.CompareTo(other) == 0;
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
