using System;

namespace AIE_18_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 2 numbers and either, 'add', 'sub', 'exp'");
            Console.WriteLine(Calculate(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), Console.ReadLine()));
        }
        private static double Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "add":
                    return num1 + num2;
                case "sub":
                    return num1 - num2;
                case "exp":
                    return Math.Pow(num1, num2);
                default:
                    throw new Exception($"The operation {operation} is not supported");
            };
        }
    }
}
