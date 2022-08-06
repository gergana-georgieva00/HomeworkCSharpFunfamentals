using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(@|#)(?<word1>[a-zA-Z]{3,})\1\1(?<word2>[a-zA-Z]{3,})";
            MatchCollection matches = Regex.Matches(input, regex);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            int validCount = 0;
            List<string> mirrorWords = new List<string>();
            foreach (Match match in matches)
            {
                var word1 = match.Groups["word1"].Value;
                var word2 = match.Groups["word2"].Value;

                char[] reversed = word1.ToCharArray();
                Array.Reverse(reversed);
                string revStr = new string(reversed);

                if (revStr == word2)
                {
                    validCount++;
                    mirrorWords.Add($"{word1} <=> {word2}");
                }
            }

            if (validCount == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"The mirror words are:{Environment.NewLine}{string.Join(", ", mirrorWords)}");
            }
        }
    }
}
