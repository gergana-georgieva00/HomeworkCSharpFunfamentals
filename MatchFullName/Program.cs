using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            Regex regex = new Regex(@"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b");
            MatchCollection matches = regex.Matches(names);

            foreach (var match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}
