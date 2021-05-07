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
            Console.Write(700 * sid);
            Console.Write(" ");
            Console.WriteLine(StarDate.DaysPer700Years);

            Console.Write(1400 * sid);
            Console.Write(" ");
            Console.WriteLine(2 * StarDate.DaysPer700Years);

        }
    }
}