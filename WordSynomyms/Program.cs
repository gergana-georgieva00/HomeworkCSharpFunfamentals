using System;
using System.Collections.Generic;

namespace WordSynomyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (wordSynonyms.ContainsKey(word))
                {
                    wordSynonyms[word].Add(synonym);
                }
                else
                {
                    wordSynonyms[word] = new List<string>();
                    wordSynonyms[word].Add(synonym);
                }
            }

            foreach (var wordSynonymPair in wordSynonyms)
            {
                Console.Write(wordSynonymPair.Key + " - ");
                Console.WriteLine(string.Join(", ", wordSynonymPair.Value));
            }
        }
    }
}
