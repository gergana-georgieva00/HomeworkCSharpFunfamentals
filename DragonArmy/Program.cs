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
                string damage = input[2];
                string health = input[3];
                string armor = input[4];

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
                                    dragon.Damage = double.Parse(damage);
                                    dragon.Health = double.Parse(health);
                                    dragon.Armor = double.Parse(armor);
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
            foreach (var kvp in dragons)
            {
                double avDamage = 0.0;
                double avHealth = 0.0;
                double avArmor = 0.0;

                //foreach (var currDragon in kvp.Value)
                //{
                //    avDamage += currDragon.Damage;
                //    avHealth += currDragon.Health;
                //    avArmor += currDragon.Armor;
                //}

                //avDamage /= (double)kvp.Value.Count;
                //avHealth /= (double)kvp.Value.Count;
                //avArmor /= (double)kvp.Value.Count;

                Console.WriteLine($"{kvp.Key}::({kvp.Value.Select(x => x.Damage).Average():f2}/{kvp.Value.Select(x => x.Health).Average():f2}/{kvp.Value.Select(x => x.Damage).Average():f2})");

                foreach (var currDragon in kvp.Value)
                {
                    Console.WriteLine($"-{currDragon.Name} -> damage: {currDragon.Damage}, health: {currDragon.Health}, armor: {currDragon.Armor}");
                }
            }
        }
    }

    class Dragon
    {
        public Dragon(string name, string damage, string health, string armor)
        {
            this.Name = name;

            if (damage.ToString() == "null")
            {
                this.Damage = 45;
            }
            else
            {
                this.Damage = double.Parse(damage);
            }

            if (health.ToString() == "null")
            {
                this.Health = 250;
            }
            else
            {
                this.Health = double.Parse(health);
            }

            if (armor.ToString() == "null")
            {
                this.Armor = 10;
            }
            else
            {
                this.Armor = double.Parse(armor);
            }
        }

        public string Name { get; set; }
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
    }
}
