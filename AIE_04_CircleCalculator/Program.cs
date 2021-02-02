using System;

namespace AIE_04_CircleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = 2.5;
            double area = Math.Pow(radius,2) * Math.PI;
            double circumference = 2 * Math.PI * radius;
            Console.WriteLine($"The area of this circle is {area}");
            Console.WriteLine($"The circumference of this circle is {circumference}");
        }
    }
}
