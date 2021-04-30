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
            double s = 365.25636;
            double s7 = s * 7;
            Console.WriteLine(StarDate.DaysPer7Years);
            Console.WriteLine(s7);
            Console.WriteLine(StarDate.DaysPer45Years);
            Console.WriteLine(s7 * 5);
            Console.WriteLine(StarDate.DaysPer140Years);
            double s140 = s * 140;
            Console.WriteLine(s140);
            Console.WriteLine(StarDate.DaysPer700Years);
            Console.WriteLine(s * 700);
            Console.WriteLine(StarDate.DaysPer700Years * 2);
            Console.WriteLine(s * 1400);
        }
    }
}
