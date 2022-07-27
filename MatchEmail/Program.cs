using System;
using System.Text.RegularExpressions;

namespace MatchEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "valid123@email.bg invalid*name@emai1.bg";

            Regex regex = new Regex(@"[a-zA-Z0-9_]+@[a-zA-Z]+\.[a-zA-Z]+");
            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
