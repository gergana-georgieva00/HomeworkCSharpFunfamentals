using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(@|#)(?<word1>[a-zA-Z]{3,})\1\1(?<word2>[a-zA-Z]{3,})\1";

            bool areWords = false;
            List<string> mirrorWords = new List<string>();

            int wordCount = 0;
            MatchCollection matches = Regex.Matches(input, regex);
            foreach (Match match in matches)
            {
                var word1 = match.Groups["word1"].Value;
                var word2 = match.Groups["word2"].Value;

                wordCount++;

                char[] reversed = word2.ToCharArray();
                Array.Reverse(reversed);
                string word2Rev = new string(reversed);

                if (word1 == word2Rev)
                {
                    areWords = true;
                    mirrorWords.Add(new string($"{word1} <=> {word2}"));
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{wordCount} word pairs found!");
            }

            if (areWords)
            {
                Console.WriteLine($"The mirror words are:");

                Console.WriteLine($"{string.Join(", ", mirrorWords)}");
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
