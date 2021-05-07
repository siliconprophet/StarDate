using System;
using StarLib;

namespace ConsoleApp1
{
    class Program
    {
        private static double sid = 365.25636;
        private static double trop = 365.24219;
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
            int i = 1;
            while (i < 100)
            {
                //Console.Write(i);
                //Console.Write(" ");
                Write140(i);
                i++;
            }
        }

        private static void Write140(int v)
        {
            double t = trop * 140 * v;
            double y = StarDate.DaysPer140Years * v;
            double s = sid * 140 * v;
            Console.WriteLine(v);
            //Console.WriteLine(v * 140 + " " + v * 140 + " " + t + " " + y + " " + s);
            //Console.WriteLine((y - t) + " " + (s - y));
            Console.WriteLine((y - t) / 7 + " " + (s - y) / 7);
        }

        private static void WriteYears(int v)
        {
            Console.Write(v * 365.25636);
            Console.Write(" ");
            Console.WriteLine(v / 1400 * StarDate.DaysPer1400Years /*+ v / 1400 * StarDate.DaysPer140Years + v / 35 * StarDate.DaysPer35Years + v / 7 * StarDate.DaysPer7Years*/);
        }
    }
}
