using System;
using System.Collections.Generic;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> chars = FindMiddle(input);

            foreach (var item in chars)
            {
                Console.Write(item);
            }
        }

        static List<char> FindMiddle(string input)
        {
            int middle = input.Length / 2;
            List<char> chars = new List<char>();

            if (input.Length % 2 == 0)
            {
                chars.Add(input[middle - 1]);
                chars.Add(input[middle]);
            }
            else
            {
                chars.Add(input[middle]);
            }

            return chars;
        }
    }
}
