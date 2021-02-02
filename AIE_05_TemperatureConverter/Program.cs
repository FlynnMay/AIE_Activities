using System;

namespace AIE_05_TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the current temperature in celcius?");
            float celsius = 0;
            float.TryParse(Console.ReadLine(), out celsius);
            //int celsius = 25;
            float fahrenheit = celsius / 5 * 9 + 32;
            Console.WriteLine($"The temperature is {celsius}°C or {fahrenheit}°F");

            Console.WriteLine("What is the current temperature in fahrenheit?");
            fahrenheit = 0;
            float.TryParse(Console.ReadLine(), out fahrenheit);
            celsius = (fahrenheit - 32) * 5 / 9;
            Console.WriteLine($"The temperature is {fahrenheit}°F or {celsius}°C");
            
        }
    }
}
