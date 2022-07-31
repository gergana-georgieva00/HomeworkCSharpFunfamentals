using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ")
                            .Select(p => p.Trim())
                            .Where(p => !string.IsNullOrWhiteSpace(p))
                            .OrderBy(p => p)
                            .ToArray();

            string regexHealth = @"[^[0-9\+\-\*\/\. ]";
            string regexDamage = @"(\+|\-)?[0-9]+\.?[0-9]*";
            string regexMultAndDiv = @"\*|\/";

            SortedDictionary<string, Dictionary<int, double>> demons = new SortedDictionary<string, Dictionary<int, double>>();

            for (int i = 0; i < input.Length; i++)
            {
                int health = 0;
                double damage = 0.0;

                MatchCollection matchesHealth = Regex.Matches(input[i], regexHealth);
                foreach (Match match in matchesHealth)
                {
                    var currChar = char.Parse(match.Groups[0].Value);
                    health += (int)currChar;
                }

                MatchCollection matchesDamage = Regex.Matches(input[i], regexDamage);
                foreach (Match match in matchesDamage)
                {
                    var currNum = double.Parse(match.Groups[0].Value);
                    damage += currNum;
                }

                MatchCollection matchesByTwo = Regex.Matches(input[i], regexMultAndDiv);
                int starsCount = 0;
                int divisionCount = 0;

                foreach (Match match in matchesByTwo)
                {
                    var currSymbol = match.Groups[0].Value;

                    if (currSymbol == "*")
                    {
                        starsCount++;
                    }
                    else
                    {
                        divisionCount++;
                    }
                }

                if (starsCount > 0 && damage != 0)
                {
                    for (int j = 0; j < starsCount; j++)
                    {
                        damage *= 2;
                    }
                }

                if (divisionCount > 0 && damage != 0)
                {
                    for (int j = 0; j < divisionCount; j++)
                    {
                        damage /= 2;
                    }
                }

                demons.Add(input[i], new Dictionary<int, double>());
                demons[input[i]].Add(health, damage);
            }

            foreach (var pair in demons)
            {
                Console.Write($"{pair.Key} - ");

                foreach (var hd in pair.Value)
                {
                    Console.WriteLine($"{hd.Key} health, {hd.Value:f2} damage");
                }
            }
        }
    }
}
