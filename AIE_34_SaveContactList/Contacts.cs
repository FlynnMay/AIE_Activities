using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_34_SaveContactList
{
    class Contact
    {
        public string name = "";
        public string email = "";
        public string phone = "";
        public static string namePrefix = "name: ";
        public static string emailPrefix = "email: ";
        public static string phonePrefix = "phone: ";

        public Contact()
        {

        }

        public Contact(string name, string email, string phone)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public void Print()
        {
            Console.WriteLine($"{name} {email} {phone}");
        }

    }
}
