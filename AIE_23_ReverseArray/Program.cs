using System;
using System.Linq;

namespace AIE_23_ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            var reversed = ReverseArray(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}, ");
            }

            Console.WriteLine("");

            for (int i = 0; i < reversed.Length; i++)
            {
                Console.Write($"{reversed[i]}, ");
            }
        }

        private static int[] ReverseArray(int[] numbers)
        {
            return numbers.Reverse().ToArray();

            //int[] reversed = new int[numbers.Length];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    reversed[i] = numbers[numbers.Length - i - 1];
            //}
            //return reversed;
        }
    }
}
