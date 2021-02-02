using System;

namespace AIE_01_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // string variables
            string aFriend = "Bill";
            Console.WriteLine(aFriend);

            aFriend = "Maira";
            Console.WriteLine(aFriend);

            // using string variables
            Console.WriteLine("Hello " + aFriend);
            Console.WriteLine($"Hello {aFriend}");

            string firstFriend = "Maria";
            string secondFriend = "Sage";
            Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");

            // string length
            Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters");
            Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters");

            // string trimming
            string greeting = "     Hello World!    ";
            Console.WriteLine($"[{greeting}]");

            string trimmedGreeting = greeting.TrimStart();
            Console.WriteLine($"[{trimmedGreeting}]");

            trimmedGreeting = greeting.TrimEnd();
            Console.WriteLine($"[{trimmedGreeting}]");

            trimmedGreeting = greeting.Trim();
            Console.WriteLine($"[{trimmedGreeting}]");

            // string replace
            string sayHello = "Hello World!";
            Console.WriteLine(sayHello);
            sayHello = sayHello.Replace("Hello", "Greetings");
            Console.WriteLine(sayHello);

            // checking what a string contains
            string songLyrics = "You say goodbye, and I say hello";
            Console.WriteLine(songLyrics.Contains("goodbye"));
            Console.WriteLine(songLyrics.Contains("greetings"));

            Console.WriteLine(songLyrics.StartsWith("You"));
            Console.WriteLine(songLyrics.StartsWith("goodbye"));

            Console.WriteLine(songLyrics.EndsWith("hello"));
            Console.WriteLine(songLyrics.EndsWith("goodbye"));

            // numbers
            int a = 18;
            int b = 6;
            int c = a + b;
            Console.WriteLine(c);

            c = a - b;
            c = a * b;
            c = a / b;

            // order of operations
             a = 5;
             b = 4;
             c = 2;
             int d = a + b * c;
            Console.WriteLine(d);

            d = (a + b) * c;
            Console.WriteLine(d);

            d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            Console.WriteLine(d);

            // int division returns int
            a = 7;
            b = 4;
            c = 3;
            d = (a + b) / c;
            Console.WriteLine(d);

            // int precision
            a = 7;
            b = 4;
            c = 3;
            d = (a + b) / c;
            int e = (a + b) % c;
            Console.WriteLine($"quotient: {d}");
            Console.WriteLine($"remainder: {e}");

            // int limits
            int max = int.MaxValue;
            int min = int.MinValue;
            Console.WriteLine($"The range of intefers is {min} to {max}");

            // overflow example
            int what = max + 3;
            Console.WriteLine($"An example of overflow: {what}");

            // double variable
            double a2 = 5;
            double b2 = 4;
            double c2 = 2;
            double d2 = (a2 + b2) / c2;
            Console.WriteLine(d2);

            // answer includes decimal, try a more complicated expression
            a2 = 19;
            b2 = 23;
            c2 = 8;
            d2 = (a2 + b2) / c2;
            Console.WriteLine(d2);

            // double max and min
            double max2 = double.MaxValue;
            double min2 = double.MinValue;
            Console.WriteLine($"The range of double is {max2} to {min2}");

            // doubles rounding errors
            double third = 1.0 / 3.0;
            Console.WriteLine(third);

            // decimal variable min and max
            decimal min3 = decimal.MinValue;
            decimal max3 = decimal.MaxValue;
            Console.WriteLine($"The range of the decimal is {min3} to {max3}");

            // range on a decimal is smaller than a double
            a2 = 1.0;
            b2 = 3.0;
            Console.WriteLine(a2 / b2);

            decimal a3 = 1.0M;
            decimal b3 = 3.0M;
            Console.WriteLine(a3 / b3);

            // calculationg the area of a circle
            double radius = 2.50;
            double area = Math.PI * radius * radius;
            Console.WriteLine(area);
        }
    }
}
