using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[a-zA-Z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            List<string> furniture = new List<string>();

            string input;
            double priceTotal = 0.0;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                MatchCollection matches = Regex.Matches(input, regex, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    var name = match.Groups["name"].Value;
                    var price = double.Parse(match.Groups["price"].Value);
                    var quantity = int.Parse(match.Groups["quantity"].Value);

                    furniture.Add(name);
                    priceTotal += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            if (furniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furniture));
            }
           
            Console.WriteLine($"Total money spend: {priceTotal:f2}");
        }
    }
}
