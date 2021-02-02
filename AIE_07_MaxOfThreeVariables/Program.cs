using System;
using System.Collections.Generic;

namespace AIE_07_MaxOfThreeVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please enter a number");
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            numbers.Sort();
            Console.WriteLine($"The highest number is {numbers[numbers.Count - 1]}");
        }
    }
}
