using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");

                if (plants.Any(p => p.Name == input[0]))
                {
                    Plant currPlant = plants.Find(p => p.Name == input[0]);
                    currPlant.Rarity = int.Parse(input[1]);
                }
                else
                {
                    Plant plant = new Plant(input[0], int.Parse(input[1]));
                    plants.Add(plant);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] splCommand = command.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Rate"))
                {
                    if (plants.Any(p => p.Name == splCommand[1]))
                    {
                        Plant currPlant = plants.Find(p => p.Name == splCommand[1]);
                        currPlant.Ratings.Add(int.Parse(splCommand[2]));
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command.Contains("Update"))
                {
                    if (plants.Any(p => p.Name == splCommand[1]))
                    {
                        Plant currPlant = plants.Find(p => p.Name == splCommand[1]);
                        currPlant.Rarity = int.Parse(splCommand[2]);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    if (plants.Any(p => p.Name == splCommand[1]))
                    {
                        Plant currPlant = plants.Find(p => p.Name == splCommand[1]);
                        currPlant.Ratings = new List<int>();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                if (plant.Ratings.Count == 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: 0.00");
                }
                else
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Ratings.Average():f2}");
                }
            }
        }
    }

    class Plant
    {
        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Ratings = new List<int>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }
    }
}
