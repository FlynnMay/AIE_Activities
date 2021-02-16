using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_34_SaveContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("bob", "bob@email.com", "12345678"));
            contacts.Add(new Contact("fred", "", ""));
            contacts.Add(new Contact("ted", "", "12345678"));

            // save to file
            SerialiseContactList("contacts.txt", contacts);

            // clear them out
            contacts = new List<Contact>();

            // read from file            
            foreach (var contact in DeSerialiseContactList("contacts.txt", contacts))
            {
                contact.Print();
            }

        }

        static void SerialiseContactList(string filename, List<Contact> contacts)
        {
            // TODO save all contacts to file.
            using (StreamWriter sw = File.CreateText(filename))
            {
                foreach (var contact in contacts)
                {
                    if(!string.IsNullOrWhiteSpace(contact.name)) sw.WriteLine(Contact.namePrefix + contact.name);
                    if (!string.IsNullOrWhiteSpace(contact.email)) sw.WriteLine(Contact.emailPrefix + contact.email);
                    if (!string.IsNullOrWhiteSpace(contact.phone)) sw.WriteLine(Contact.phonePrefix + contact.phone);
                    sw.WriteLine("");
                }
            }
        }

        static List<Contact> DeSerialiseContactList(string filename, List<Contact> contacts)
        {
            // TODO load all contacts from file.
            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string name = "";
                    string email = "";
                    string phone = "";

                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (s.StartsWith(Contact.namePrefix)) name = s.Replace(Contact.namePrefix, "");
                            else if (s.StartsWith(Contact.emailPrefix)) email = s.Replace(Contact.emailPrefix, "");
                            else if (s.StartsWith(Contact.phonePrefix)) phone = s.Replace(Contact.phonePrefix, "");
                        }
                        else
                        {
                            contacts.Add(new Contact(name, email, phone));
                            name = "";
                            email = "";
                            phone = "";
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found...");
            }

            return contacts;
        }
    }

}
