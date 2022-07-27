using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "I am born on 30-Dec-1994. My father is born on the 9-Jul-1995. 01-July-2000 is not a valid date.";

            Regex regex = new Regex(@"[0-9]{1,2}-([A-Z][a-z]{2})-[1-9]{4}");
            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
