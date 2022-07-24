using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string input = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                while (input.Contains(word))
                {
                    input = input.Replace(word, new string('*', word.Length));
                }
            }

            Console.WriteLine(input);
        }
    }
}
