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
            int i = 0;
            while (i <= 14000)
            {
                Console.WriteLine(StarDate.leapLevel(i++));
            }
        }
    }
}