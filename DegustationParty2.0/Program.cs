using System;
using System.Collections.Generic;

namespace DegustationParty2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int unlikedCount = 0;

            Dictionary<string, Dictionary<string, List<string>>> guests = new Dictionary<string, Dictionary<string, List<string>>>();

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splCommand = command.Split('-');

                string guestName = splCommand[1];
                string meal = splCommand[2];

                if (command.Contains("Like"))
                {
                    if (guests.ContainsKey(guestName))
                    {
                        if (!guests[guestName]["Like"].Contains(meal))
                        {
                            guests[guestName]["Like"].Add(meal);
                        }
                    }
                    else
                    {
                        guests.Add(guestName, new Dictionary<string, List<string>>());
                        guests[guestName].Add("Like", new List<string>());
                        guests[guestName]["Like"].Add(meal);
                    }
                }
                else
                {
                    if (guests.ContainsKey(guestName))
                    {
                        if (!guests[guestName]["Like"].Contains(meal))
                        {
                            Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            guests[guestName]["Like"].Remove(meal);
                            unlikedCount++;
                            Console.WriteLine($"{guestName} doesn't like the {meal}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                }
            }

            foreach (var kvp in guests)
            {
                if (kvp.Value.ContainsKey("Like"))
                {
                    string name = kvp.Key;
                    Console.WriteLine($"{kvp.Key}: {string.Join(", ", guests[name]["Like"])}");
                }
            }

            Console.WriteLine($"Unliked meals: {unlikedCount}");
        }
    }

    //class Guest
    //{
    //    public string LikeDislike { get; set; }
    //    public List<string> Meals { get; set; }
    //}
}
