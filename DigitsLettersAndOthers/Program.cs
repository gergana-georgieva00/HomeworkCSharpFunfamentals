using System;
using System.Collections.Generic;

namespace DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            List<char> digits = new List<char>();
            List<char> lettes = new List<char>();
            List<char> other = new List<char>();

            foreach (var currChar in input)
            {
                if (Char.IsDigit(currChar))
                {
                    digits.Add(currChar);
                }
                else if (Char.IsLetter(currChar))
                {
                    lettes.Add(currChar);
                }
                else
                {
                    other.Add(currChar);
                }
            }

            Console.WriteLine(string.Join("", digits));
            Console.WriteLine(string.Join("", lettes));
            Console.WriteLine(string.Join("", other));
        }
    }
}
