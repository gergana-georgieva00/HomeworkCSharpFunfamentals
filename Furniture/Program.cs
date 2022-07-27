using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<furnitureName>[a-zA-Z]+)<<(?<price>\d+\.?(\d+)?)!(?<quantity>\d+)");
            Dictionary<string, string> furniture = new Dictionary<string, string>();

            string input;
            double multiplication = 0.0;
            List<double> pricesAfterMult = new List<double>();
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Captures.Count != 0)
                {
                    furniture.Add(match.Groups["furnitureName"].Value, match.Groups["price"].Value);
                    multiplication = double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                    pricesAfterMult.Add(multiplication);
                }
            }

            Console.WriteLine("Bought furniture:");
            Console.WriteLine(string.Join(Environment.NewLine, furniture.Keys));

            double sum = 0;
            foreach (var price in pricesAfterMult)
            {
                sum += price;
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
