using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> occurrencesOfChars = new Dictionary<char, int>();

            foreach (var currChar in input)
            {
                if (currChar == ' ')
                {
                    continue;
                }

                if (occurrencesOfChars.ContainsKey(currChar))
                {
                    occurrencesOfChars[currChar]++;
                }
                else
                {
                    occurrencesOfChars.Add(currChar, 1);
                }
            }

            foreach (var charOccPair in occurrencesOfChars)
            {
                Console.WriteLine($"{charOccPair.Key} -> {charOccPair.Value}");
            }
        }
    }
}
