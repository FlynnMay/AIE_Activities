using System;
using System.Linq;

namespace AIE_16_IsAVowel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a letter...");
            Console.WriteLine(IsAVowel(Console.ReadLine().ToLower().First()));
        }
        private static bool IsAVowel(char letter)
        {
            return "aeiou".Contains(letter);
        }
    }
}
