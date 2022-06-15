using System;
using System.Collections.Generic;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            List<char> result = FindCharactersInrange(first, second);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }

        static List<char> FindCharactersInrange(char first, char second)
        {
            List<char> characters = new List<char>();
            char start;
            char end;

            if (first > second)
            {
                start = second;
                end = first;
            }
            else
            {
                start = first;
                end = second;
            }

            for (char current = (char)(start + (char)1); current < end; current++)
            {
                characters.Add(current);
            }

            return characters;
        }
    }
}
