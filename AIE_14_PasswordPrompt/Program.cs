using System;

namespace AIE_14_PasswordPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "";
            string confirm = "";
            do
            {
                Console.WriteLine("Please Enter A Password");
                password = Console.ReadLine();
                Console.WriteLine("Please Confirm Your Password");
                confirm = Console.ReadLine();
            } while (password != confirm);
        }
    }
}
