using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexEmoji = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";
            string regexThreshold = @"\d";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, regexThreshold);
            BigInteger threshold = 1;

            foreach (Match match in matches)
            {
                int num = int.Parse(match.Groups[0].Value);
                threshold *= num;
            }

            MatchCollection matchesEmoji = Regex.Matches(input, regexEmoji);
            int validCount = matchesEmoji.Count;

            List<string> coolEmojis = new List<string>();

            foreach (Match match in matchesEmoji)
            {
                var emoji = match.Groups["emoji"].Value;

                int currCoolness = 0;

                foreach (char currChar in emoji)
                {
                    currCoolness += (int)currChar;
                }

                if (currCoolness > threshold)
                {
                    coolEmojis.Add(match.Groups[0].Value);
                }
            }

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{validCount} emojis found in the text. The cool ones are:{Environment.NewLine}{string.Join(Environment.NewLine, coolEmojis)}");
        }
    }
}
