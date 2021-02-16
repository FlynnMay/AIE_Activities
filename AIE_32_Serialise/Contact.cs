using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIE_32_Serialise
{
    class Contact
    {
        public string name = "";
        public string email = "";
        public string phone = "";

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
            var fileInfo = new FileInfo(filename);
            var dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);
            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine(name);
                sw.WriteLine(email);
                sw.WriteLine(phone);
            }

        }

        public void DeSerialise(string filename)
        {
            // TODO: use StreamReader to write the name, email and phone to file
            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    name = sr.ReadLine();
                    email = sr.ReadLine();
                    phone = sr.ReadLine();
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
