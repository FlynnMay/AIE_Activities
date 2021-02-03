using System;
using System.Collections.Generic;

namespace AIE_17_MaxOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 3 numbers...");
            Console.WriteLine($"The highest number is: {MaxOfThree(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()))}");
        }
        private static int MaxOfThree(int num1, int num2, int num3)
        {
            List<int> numbers = new List<int>() { num1, num2, num3 };
            numbers.Sort();
            return numbers[numbers.Count - 1];
        }
    }
}
