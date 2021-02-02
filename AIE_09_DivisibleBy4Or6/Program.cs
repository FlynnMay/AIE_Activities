using System;

namespace AIE_09_DivisibleBy4Or6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int num = int.Parse(Console.ReadLine());

            CheckNum(num, 4);
            CheckNum(num, 6);
        }
        public static void CheckNum(int input, int divider)
        {
            if (input % divider == 0)
            {
                Console.WriteLine($"The number {input} is divisible by {divider}");
            }
            else
            {
                Console.WriteLine($"The number {input} is not divisible by {divider}");
            }
        }
    }
}
