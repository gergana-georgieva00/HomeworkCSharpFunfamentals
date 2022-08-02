using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();

            string command1;
            while ((command1 = Console.ReadLine()) != "Sail")
            {
                string[] splCommand = command1.Split("||");

                Town town = new Town(splCommand[0], int.Parse(splCommand[1]), int.Parse(splCommand[2]));
                if (towns.Any(t => t.Name == splCommand[0]))
                {
                    Town currTown = towns.Find(t => t.Name == splCommand[0]);
                    currTown.Population += int.Parse(splCommand[1]);
                    currTown.Gold += int.Parse(splCommand[2]);
                }
                else
                {
                    towns.Add(town);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splCommand = command.Split("=>");
                Town currTown = towns.Find(t => t.Name == splCommand[1]);

                if (command.Contains("Plunder"))
                {
                    string townName = splCommand[1];
                    int people = int.Parse(splCommand[2]);
                    int gold = int.Parse(splCommand[3]);

                    currTown.Population -= people;
                    currTown.Gold -= gold;

                    Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (currTown.Population <= 0 || currTown.Gold <= 0)
                    {
                        towns.Remove(currTown);
                        Console.WriteLine($"{currTown.Name} has been wiped off the map!");
                    }
                }
                else
                {
                    string townName = splCommand[1];
                    int gold = int.Parse(splCommand[2]);

                    if (gold <= 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        currTown.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {currTown.Gold} gold.");
                    }
                }
            }

            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (Town town in towns)
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class Town
    {
        public Town(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
