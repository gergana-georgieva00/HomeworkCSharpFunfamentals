using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            Dictionary<string, int> wordsWithOccurrences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordsWithOccurrences.ContainsKey(word.ToLower()))
                {
                    wordsWithOccurrences[word.ToLower()]++;
                }
                else
                {
                    wordsWithOccurrences.Add(word.ToLower(), 1);
                }
            }

            foreach (var wordOccPair in wordsWithOccurrences)
            {
                if (!(wordOccPair.Value % 2 == 0))
                {
                    Console.Write(wordOccPair.Key + " ");
                }
            }
        }
    }
}
