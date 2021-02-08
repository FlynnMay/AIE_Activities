using System;
using System.Linq;

namespace CalculateAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            Console.WriteLine(CalculateAverage(numbers));
        }

        private static float CalculateAverage(int[] numbers)
        {
            return (float) numbers.Average();

            // old code
            //float sum = 0;
            //foreach (var i in numbers)
            //{
            //    sum += i;
            //}
            //return sum / numbers.Length;
        }
    }
}
