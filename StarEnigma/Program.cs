using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string regexSTAR = @"[starSTAR]";
            string regexNewInput = @"^[^@,\-!:>]*@(?<planet>[a-zA-Z]+)[^@,\-!:>]*:(?<population>[0-9]+)[^@,\-!:>]*\!(?<attack>[A|D])\![^@,\-!:>]*->(?<count>[0-9]+)";

            Dictionary<string, List<string>> attackedPlanets = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int count = 0;

                MatchCollection matches = Regex.Matches(input, regexSTAR);
                foreach (Match match in matches)
                {
                    count++;
                }

                StringBuilder sb = new StringBuilder(input);
                for (int j = 0; j < input.Length; j++)
                {
                    sb[j] = (char)((int)input[j] - count);
                    input = sb.ToString();
                }

                MatchCollection matches2 = Regex.Matches(input, regexNewInput);
                foreach (Match match in matches2)
                {
                    var planetName = match.Groups["planet"].Value;
                    var population = int.Parse(match.Groups["population"].Value);
                    var attackType = match.Groups["attack"].Value;
                    var soldierCount = int.Parse(match.Groups["count"].Value);

                    if (attackType == "A")
                    {
                        if (attackedPlanets.ContainsKey("A"))
                        {
                            attackedPlanets["A"].Add(planetName);
                        }
                        else
                        {
                            attackedPlanets.Add("A", new List<string>());
                            attackedPlanets["A"].Add(planetName);
                        }
                    }
                    else
                    {
                        if (attackedPlanets.ContainsKey("D"))
                        {
                            attackedPlanets["D"].Add(planetName);
                        }
                        else
                        {
                            attackedPlanets.Add("D", new List<string>());
                            attackedPlanets["D"].Add(planetName);
                        }
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets["A"].Count}");
            attackedPlanets = attackedPlanets.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var planet in attackedPlanets["A"])
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {attackedPlanets["D"].Count}");
            foreach (var planet in attackedPlanets["D"])
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
