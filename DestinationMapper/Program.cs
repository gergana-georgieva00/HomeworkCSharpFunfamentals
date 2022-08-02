using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(=|/)(?<location>[A-Z][a-zA-Z]{2,})\1";

            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, regex);
            int travelPoints = 0;

            List<string> destionations = new List<string>();

            foreach (Match match in matches)
            {
                travelPoints += match.Groups["location"].Value.Length;
                destionations.Add(match.Groups["location"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destionations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
