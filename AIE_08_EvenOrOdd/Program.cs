using System;

namespace AIE_08_EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(num % 2 == 0 ? $"The number {num} is even" : $"The number {num} is odd");
/*            if (num % 2 == 0)
            {
                Console.WriteLine($"The number {num} is even");
            }
            else 
            {
                Console.WriteLine($"The number {num} is odd");
            }*/
        }
    }
}
