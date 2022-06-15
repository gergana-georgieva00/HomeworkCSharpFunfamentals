using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Console.WriteLine(CountVowels(input));
        }

        static int CountVowels(char[] input)
        {
            int counter = 0;

            foreach (var character in input)
            {
                if (char.ToLower(character) == 'a' || char.ToLower(character) == 'e' || char.ToLower(character) == 'i' || char.ToLower(character) == 'o' || char.ToLower(character) == 'u')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
