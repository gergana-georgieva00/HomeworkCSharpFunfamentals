using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<char> output = new List<char>();

            foreach (var element in input.ToCharArray())
            {
                if (output.Count == 0 || output.Last() != element)
                {
                    output.Add(element);
                }
            }

            string result = new string(output.ToArray());

            Console.WriteLine(string.Join("", output));
        }
    }
}
