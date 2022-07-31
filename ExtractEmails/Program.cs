using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ','});

            List<string> emails = new List<string>();

            string regex = @"(?<user>^[a-zA-Z0-9]+([\.\-_])?[a-zA-Z0-9]*)@(?<host>[a-zA-Z]+(-)?[a-zA-Z]*(\.[a-zA-Z]+(-)?[a-zA-Z]+)+)";

            for (int i = 0; i < input.Length; i++)
            {
                MatchCollection matches = Regex.Matches(input[i], regex);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        emails.Add(match.Value);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, emails));
        }
    }
}
