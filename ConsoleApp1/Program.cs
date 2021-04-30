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
            Console.Write(45 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer45Years);
            Console.Write(140 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer140Years);
            Console.Write(1400 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer1400Years);
            Console.Write(2800 * s);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer1400Years * 2);
        }
    }
}
