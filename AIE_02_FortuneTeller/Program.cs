using System;

namespace AIE_02_FortuneTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            uint numberOfChilderen = (uint) random.Next(0, 1000);
            string partnersName = "Jim";
            string location = "Sydney";
            string jobTitle = "crash test dummy";

            string output = string.Format("You will be a {0} in {1}, and married to {2} with {3} kids", jobTitle, location, partnersName, numberOfChilderen);

            Console.WriteLine(output);
        }
    }
}
