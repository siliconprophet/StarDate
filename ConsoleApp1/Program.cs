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
            Console.WriteLine(StarDate.DaysPer140Years / 7);
        }
    }
}