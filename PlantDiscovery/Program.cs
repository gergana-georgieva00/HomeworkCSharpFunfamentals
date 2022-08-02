using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
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

                string plantName = input[0];
                int rarity = int.Parse(input[1]);

                if (plants.Any(p => p.Name == plantName))
                {
                    Plant currPlant = plants.Find(p => p.Name == plantName);
                    currPlant.Rarity = rarity;
                }
                else
                {
                    Plant plant = new Plant(plantName, rarity);
                    plants.Add(plant);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] splCommand = command.Split(new[] { " - ", ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Rate"))
                {
                    if (plants.Any(p => p.Name == splCommand[1]))
                    {
                        Plant currPlant = plants.Find(p => p.Name == splCommand[1]);
                        currPlant.Rating.Add(int.Parse(splCommand[2]));
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
                        currPlant.Rating = new List<int>();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants)
            {
                if (plant.Rating.Count != 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {((double)plant.Rating.Sum() / (double)plant.Rating.Count):f2}");
                }
                else
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: 0.00");
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
            this.Rating = new List<int>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }
    }
}
