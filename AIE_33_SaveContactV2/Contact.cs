using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIE_33_SaveContactV2
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

        public void Serialise(string filename)
        {
            // TODO: use StreamWriter to write the name, email and phone to file

            using (StreamWriter sw = File.CreateText(filename))
            {
                if (!string.IsNullOrWhiteSpace(name)) sw.WriteLine(namePrefix + name);
                if (!string.IsNullOrWhiteSpace(email)) sw.WriteLine(emailPrefix + email);
                if (!string.IsNullOrWhiteSpace(phone)) sw.WriteLine(phonePrefix + phone);
            }

        }

        public void DeSerialise(string filename)
        {
            // TODO: use StreamReader to write the name, email and phone to file
            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.StartsWith(namePrefix)) name = s.Replace(namePrefix, "");
                        else if (s.StartsWith(emailPrefix)) email = s.Replace(emailPrefix, "");
                        else if (s.StartsWith(phonePrefix)) phone = s.Replace(phonePrefix, "");
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found...");
            }
        }

        public void Print()
        {
            Console.WriteLine($"{name} {email} {phone}");
        }

    }
}
