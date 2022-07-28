using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ").ToList();

            Dictionary<string, int> racers = new Dictionary<string, int>();

            string info;
            while ((info = Console.ReadLine()) != "end of race")
            {
                string regex = @"[a-zA-Z0-9]";

                var matches = Regex.Matches(info, regex).Select(x => x.Groups[0].Value);
                string name = "";
                int sum = 0;

                foreach (var symbol in matches)
                {
                    if (Char.IsLetter(char.Parse(symbol)))
                    {
                        name = name + symbol;
                    }
                    else
                    {
                        sum += int.Parse(symbol);
                    }
                }

                if (participants.Contains(name))
                {
                    if (racers.ContainsKey(name))
                    {
                        racers[name] += sum;
                    }
                    else
                    {
                        racers.Add(name, sum);
                    }
                }
            }

            int counter = 1;
            racers = racers.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var test1 = racers.OrderByDescending(x => x.Value).ToList();
            foreach (var pair in test1)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {pair.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {pair.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {pair.Key}");
                    break;
                }

                counter++;
            }
        }
    }
}
