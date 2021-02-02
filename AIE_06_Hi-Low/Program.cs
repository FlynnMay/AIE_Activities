using System;

namespace AIE_06_Hi_Low
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int input = int.Parse(Console.ReadLine());
            if (input > 50)
            {
                Console.WriteLine($"{input} is greater than 50");
            }
            else if (input < 50)
            {
                Console.WriteLine($"{input} is less than 50");
            }
            else
            {
                Console.WriteLine($"{input} is 50");
            }
        }
    }
}
