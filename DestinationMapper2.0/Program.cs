using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();
            string regex = @"(=|\/)(?<destination>[A-Z][a-zA-Z]{2,})\1";

            List<string> destinations = new List<string>();
            int points = 0;

            MatchCollection matches = Regex.Matches(places, regex);
            foreach (Match match in matches)
            {
                destinations.Add(match.Groups["destination"].Value);
                points += match.Groups["destination"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
