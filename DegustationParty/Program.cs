using System;
using System.Collections.Generic;
using System.Linq;

namespace DegustationParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Guest> guestsLikes = new List<Guest>();
            List<Guest> guestsDislikes = new List<Guest>();
            List<string> guestNames = new List<string>();
            int unlikedCount = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splCommand = command.Split('-');

                string guestName = splCommand[1];
                string meal = splCommand[2];

                if (!guestNames.Contains(guestName))
                {
                    guestNames.Add(guestName);
                }

                if (command.Contains("Like"))
                {
                    if (guestsLikes.Any(g => g.Name == guestName))
                    {
                        Guest currGuest = guestsLikes.Find(g => g.Name == guestName);

                        if (!currGuest.Meals.Contains(meal))
                        {
                            currGuest.Meals.Add(meal);
                        }
                    }
                    else
                    {
                        Guest guest = new Guest("Like", guestName);
                        guest.Meals.Add(meal);
                        guestsLikes.Add(guest);
                    }
                }
                else
                {
                    if (guestsLikes.Any(g => g.Name == guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                    else
                    {
                        Guest currGuest = guestsLikes.Find(g => g.Name == guestName);

                        //if (currGuest.Meals == null)
                        //{

                        //}
                        //else
                        //{

                        //}

                        if (currGuest.Meals != null && currGuest.Meals.Contains(meal))
                        {
                            currGuest.Meals.Remove(meal);
                            Console.WriteLine($"{guestName} doesn't like the {meal}.");
                            unlikedCount++;
                        }
                        else
                        {
                            Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                        }
                    }
                }
            }

            foreach (var guest in guestsLikes)
            {
                Console.WriteLine($"{guest.Name}: {string.Join(", ", guest.Meals)}");
            }

            Console.WriteLine($"Unliked meals: {unlikedCount}");
        }
    }

    class Guest
    {
        public Guest(string likeDislike, string name)
        {
            this.LikeDislike = likeDislike;
            this.Name = name;
            this.Meals = new List<string>();
        }

        public string LikeDislike { get; set; }
        public string Name { get; set; }
        public List<string> Meals { get; set; } = new List<string>();
    }
}
