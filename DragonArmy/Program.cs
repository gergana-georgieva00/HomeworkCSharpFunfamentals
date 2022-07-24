using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            int n = int.Parse(Console.ReadLine());

            // read the data
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];
                string name = input[1];
                int damage = int.Parse(input[2]);
                int health = int.Parse(input[3]);
                int armor = int.Parse(input[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                    dragons[type].Add(new Dragon(name, damage, health, armor));
                }
                else
                {
                    if (dragons[type].Any(x => x.Name == name))
                    {
                        foreach (var dragonList in dragons.Values)
                        {
                            foreach (var dragon in dragonList)
                            {
                                if (dragon.Name == name)
                                {
                                    dragon.Damage = damage;
                                    dragon.Health = health;
                                    dragon.Armor = armor;
                                }
                            }
                        }
                    }
                    else
                    {
                        dragons[type].Add(new Dragon(name, damage, health, armor));
                    }
                }
            }

            // order => 
            // Type is preserved as in the order of input,
            // but dragons are sorted alphabetically by name

            dragons = dragons.ToDictionary(d => d.Key, d => d.Value.OrderBy(d => d.Name).ToList());

            // print stats

        }
    }

    class Dragon
    {
        public Dragon(string name, int damage, int health, int armor)
        {
            this.Name = name;

            if (damage.ToString() == "null")
            {
                this.Damage = 45;
            }
            else
            {
                this.Damage = damage;
            }

            if (health.ToString() == "null")
            {
                this.Health = 250;
            }
            else
            {
                this.Health = health;
            }

            if (armor.ToString() == "null")
            {
                this.Armor = 10;
            }
            else
            {
                this.Armor = armor;
            }
        }

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
