using System;
using System.Linq;
using System.Collections.Generic;

namespace AIE_24_InsertNextTo
{
    class Program
    {
        static void Main(string[] args)
        {
            var words1 = new string[] { "hello", "the", "quick", "brown", "fox", "hello", "something" };

            var words2 = InsertWorld(words1);

            for (int i = 0; i < words1.Length; i++)
                Console.Write($"{words1[i]} ");

            Console.WriteLine("");

            for (int i = 0; i < words2.Length; i++)
                Console.Write($"{words2[i]} ");
        }

        private static string[] InsertWorld(string[] strings)
        {
            List<string> stringsList = strings.ToList();
            int counter = 1;

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i] == "hello")
                {
                    stringsList.Insert(i + counter , "world");
                    counter++;
                }
            }

            return stringsList.ToArray();
        }
    }
}
