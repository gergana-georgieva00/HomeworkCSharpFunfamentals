using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine().Split(", ").ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitCommand = command.Split(" - ");
                string phone = splitCommand[1];

                if (command.Contains("Add"))
                {
                    if (!phones.Contains(phone))
                    {
                        phones.Add(phone);
                    }
                }
                else if (command.Contains("Remove"))
                {
                    if (phones.Contains(phone))
                    {
                        phones.Remove(phone);
                    }
                }
                else if (command.Contains("Bonus phone"))
                {
                    string[] splitPhone = phone.Split(':');
                    string oldPhone = splitPhone[0];
                    string newPhone = splitPhone[1];

                    if (phones.Contains(oldPhone))
                    {
                        phones.Insert(phones.IndexOf(oldPhone) + 1, newPhone);
                    }
                }
                else
                {
                    if (phones.Contains(phone))
                    {
                        phones.Remove(phone);
                        phones.Add(phone);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
