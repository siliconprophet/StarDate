using System;
using StarLib;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int k = 1000;
            long m = k * k;
            long b = m * k;
            long y = 14 * b + 14 * k;
            Console.WriteLine(StarDate.isLeap(y));
            double t = 365.24219;
            Console.WriteLine(t);
            double s = 365.25636;
            _ = s * 7;
            Console.Write(7 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer7Years);
            Console.Write(35 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer35Years);
            Console.Write(140 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer140Years);
            Console.Write(1400 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer1400Years);
            Console.Write(2800 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer1400Years * 2);
            WriteYears(14000);
            WriteYears(28000);
        }

        private static void WriteYears(int v)
        {
            Console.Write(v * 365.25636);
            Console.Write(" ");
            Console.WriteLine(v / 1400 * StarDate.DaysPer1400Years /*+ v / 1400 * StarDate.DaysPer140Years + v / 35 * StarDate.DaysPer35Years + v / 7 * StarDate.DaysPer7Years*/);
        }
    }
}
