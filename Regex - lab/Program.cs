using System;
using System.Text.RegularExpressions;

namespace Regex___lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "_ (Underscores) are also word characters!";

            Regex regex = new Regex(@"[a-zA-Z]");
            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
