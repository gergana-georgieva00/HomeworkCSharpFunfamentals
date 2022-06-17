using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string[] splitInput = input.Split(' ');

                if (input.Contains("is not"))
                {
                    // if ont the list => delete
                    if (guestList.Contains(splitInput[0]))
                    {
                        guestList.Remove(splitInput[0]);
                    }
                    // if not on the list => print a message
                    else
                    {
                        Console.WriteLine($"{splitInput[0]} is not in the list!");
                    }
                }
                else
                {
                    // if ont the list => print a message
                    if (guestList.Contains(splitInput[0]))
                    {
                        Console.WriteLine($"{splitInput[0]} is already in the list!");
                    }
                    // if not on the list => add the name to the list
                    else
                    {
                        guestList.Add(splitInput[0]);
                    }
                }
            }

            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
