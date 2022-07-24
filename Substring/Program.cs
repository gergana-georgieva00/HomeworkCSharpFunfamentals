using System;
using System.Text.RegularExpressions;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string match = Console.ReadLine();
            string input = Console.ReadLine();

            while (input.Contains(match))
            {
                input = input.Remove(input.IndexOf(match), match.Length);
            }

            Console.WriteLine(input);
        }
    }
}
