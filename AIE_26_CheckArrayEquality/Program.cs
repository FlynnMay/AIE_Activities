using System;
using System.Linq;

namespace AIE_26_CheckArrayEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers1 = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            var numbers2 = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            var numbers3 = new int[] { 10, 3, 6, 6, 6, 8, 1, 7 };

            Console.WriteLine(CheckArrayEquality(numbers1, numbers2)); // true
            Console.WriteLine(CheckArrayEquality(numbers1, numbers3)); // false
        }

        private static bool CheckArrayEquality(int[] numbers1, int[] numbers2)
        { 
            if (numbers1.SequenceEqual(numbers2)) return true; 
            return false;
        }

    }
}
