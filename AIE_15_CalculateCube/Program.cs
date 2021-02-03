using System;

namespace AIE_15_CalculateCube
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to cube...");
            Console.WriteLine(CalculateCube(double.Parse(Console.ReadLine())));
        }
        private static double CalculateCube(double num)
        {
            return Math.Pow(num, 3);
        }
    }
}
