using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string regex = @"^(\$|%)(?<tag>[A-Z][a-z]{2,})\1\: \[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, regex);

                if (matches.Count == 0)
                {
                    Console.WriteLine("Valid message not found!");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (Match match in matches)
                    {
                        var firstNum = int.Parse(match.Groups[2].Value);
                        var secondNum = int.Parse(match.Groups[3].Value);
                        var thirdNum = int.Parse(match.Groups[4].Value);

                        char first = (char)firstNum;
                        char second = (char)secondNum;
                        char third = (char)thirdNum;

                        sb.Append(first.ToString());
                        sb.Append(second.ToString());
                        sb.Append(third.ToString());

                        Console.WriteLine($"{match.Groups["tag"].Value}: {sb.ToString()}");
                    }
                }
            }
        }
    }
}
