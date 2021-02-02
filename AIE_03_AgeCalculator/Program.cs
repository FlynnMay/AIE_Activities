using System;

namespace AIE_03_AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //uint year = (uint) random.Next(1950, 2021);
            //uint currentYear = 2021;
            //uint age = currentYear - year;
            //uint age = currentYear - year;
            //string output = string.Format("you were born int {0}, the year is {1}, and you are {2}", year, currentYear, age);

            DateTime currentDate = DateTime.Now;
            DateTime birthDate = new DateTime(random.Next(1910, currentDate.Year), 1, 1);
            var age = currentDate.Year - birthDate.Year;

            string output = string.Format("you were born int {0}, the year is {1}, and you are {2}", birthDate.Year, currentDate.Year, age);
            Console.WriteLine(output);
        }
    }
}
