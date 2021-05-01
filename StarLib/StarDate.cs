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
        public const int DaysPer45Years = DaysPer7Years * 5 + DaysPerWeek;
        public const int DaysPerDoubleLeapYear = DaysPerLeapYear + DaysPerWeek;
        public const int DaysPer140Years = DaysPer45Years * 4 + DaysPerWeek;
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
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(StarDate other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(DateTime other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(StarDate other)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
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
