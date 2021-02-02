using System;
using System.Collections.Generic;
using System.Linq;

namespace AIE_11_DayOfWeek2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a day");
            string day = Console.ReadLine();

            day = day.ToLower();
            day.Replace(" ", "");

            Dictionary<string, int> weekdays = new Dictionary<string, int>() 
            {
                {"monday", 1 },
                {"tuesday", 2 },
                {"wednesday", 3 },
                {"thursday", 4 },
                {"friday", 5 },
                {"saturday", 6 },
                {"sunday", 7 }
            };
            Console.WriteLine($"The day is {weekdays[day]}");
        }
    }
}
