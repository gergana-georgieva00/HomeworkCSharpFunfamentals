using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            string regex = @"[^@#\$\^]*(\@|#|\$|\^){6,}[^@#\$\^]*";

            foreach (var word in input)
            {
                if (word.Length == 0)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                if (word.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalf = word.Substring(0, word.Length / 2);
                string secondHalf = word.Substring(word.Length / 2, word.Length / 2);

                MatchCollection matches1 = Regex.Matches(firstHalf, regex);
                MatchCollection matches2 = Regex.Matches(secondHalf, regex);

                int lengthLeft = 0;
                int lengthRight = 0;
                string symbolLeft = "";
                string symbolRight = "";

                if (matches1.Count > 0 && matches2.Count > 0)
                {
                    foreach (Match match in matches1)
                    {
                        lengthLeft = match.Groups[1].Captures.Count;
                        symbolLeft = match.Groups[1].Value;
                    }

                    foreach (Match match in matches2)
                    {
                        lengthRight = match.Groups[1].Captures.Count;
                        symbolRight = match.Groups[1].Value;
                    }

                    if (lengthLeft == lengthRight && symbolLeft == symbolRight)
                    {
                        if (lengthLeft >= 6 && lengthLeft < 10)
                        {
                            Console.WriteLine($"ticket \"{word}\" - {lengthLeft}{symbolRight}");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{word}\" - {lengthRight}{symbolRight} Jackpot!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{word}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{word}\" - no match");
                }
            }
            
        }
    }
}
