using System;
using System.Collections.Generic;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Hero hero = new Hero(input[0], int.Parse(input[1]), int.Parse(input[2]));
                heroes.Add(hero);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splCommand = command.Split(" - ");

                if (command.Contains("CastSpell"))
                {
                    string heroName = splCommand[1];
                    int mpNeeded = int.Parse(splCommand[2]);
                    string spellName = splCommand[3];

                    Hero currHero = heroes.Find(h => h.Name == heroName);

                    if (currHero.MP >= mpNeeded)
                    {
                        currHero.MP -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currHero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command.Contains("TakeDamage"))
                {
                    string heroName = splCommand[1];
                    int damage = int.Parse(splCommand[2]);
                    string attacker = splCommand[3];

                    Hero currHero = heroes.Find(h => h.Name == heroName);

                    currHero.HP -= damage;

                    if (currHero.HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currHero.HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(currHero);
                    }
                }
                else if (command.Contains("Recharge"))
                {
                    string heroName = splCommand[1];
                    int amount = int.Parse(splCommand[2]);

                    Hero currHero = heroes.Find(h => h.Name == heroName);

                    if (currHero.MP + amount > 200)
                    {
                        amount = 200 - currHero.MP;
                    }
                    
                    currHero.MP += amount;

                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }
                else
                {
                    string heroName = splCommand[1];
                    int amount = int.Parse(splCommand[2]);

                    Hero currHero = heroes.Find(h => h.Name == heroName);

                    if (currHero.HP + amount > 100)
                    {
                        amount = 100 - currHero.HP;
                    }

                    currHero.HP += amount;

                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }
            }

            foreach (Hero hero in heroes)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.MP}");
            }
        }
    }

    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.HP = hp;
            this.MP = mp;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
}
