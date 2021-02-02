using System;
using System.Collections.Generic;

namespace AIE_10_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int num = int.Parse(Console.ReadLine());

            List<string> weekdays = new List<string>() {"Monday", "Tuesday", "Wednesday", "Thursday",
                                                        "Friday", "Saturday", "Sunday" };
            Console.WriteLine($"The day is {weekdays[num - 1]}");
        }
    }
}
