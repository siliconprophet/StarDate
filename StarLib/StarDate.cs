﻿using System;
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
        public const int DaysPer7Years = DaysPerYear * 7 + DaysPerWeek; //2555
        public const int DaysPerLeapYear = DaysPerYear + DaysPerWeek;
        public const int DaysPer35Years = DaysPer7Years * 5 + DaysPerWeek;
        public const int DaysPerDoubleLeapYear = DaysPerLeapYear + DaysPerWeek;
        public const int DaysPer140Years = DaysPer35Years * 4 + DaysPerWeek;
        public const int DaysPerTripleLeapYear = DaysPerDoubleLeapYear + DaysPerWeek;
        public const int WeeksPer140Years = DaysPer140Years / 7; //7305
        //13 additional leap weeks will be added in 100 iterations of 140 years to get 730513 weeks per 14000 Years
        //12 cycles of 8 cycles of 140 years has a quadruple leap year, plus an irregular 4 x 140 cycle at the end
        public const long DaysPer14000Years = 5113591; //rounding slightly up from 14000 sidereal years 5113589.04 days
        public const long WeeksPer14000Years = DaysPer14000Years / 7; //730513
        public const long DaysToManu = DaysPer14000Years * 1000000;

        //struct data
        private Date _date;
        private TimeOfDay _time;
        private StarZone _timeZone;

        public StarDate(DateTime other) : this()
        {
        }

        public BigInteger Ticks { get; private set; }

        //Leap Year Calculations
        public static int leapLevel(long year)
        {
            if(year % 7 != 0)
            {
                return 0;
            }
            else if (year % 35 != 0)
            {
                return 1;
            }
            else if (year % 140 != 0)
            {
                return 2;
            }
            year %= 14000;
            int CXLannum = (int)(year / 140);
            if (CXLannum % 8 == 0)
            {
                return 4;
            }
            else
            {
                return 3;
            }
            throw new NotImplementedException();
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
