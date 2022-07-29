using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"%(?<name>[A-Z][a-z]+)%([^\|\$%\.])*<(?<product>\w+)>([^\|\$%\.])*\|(?<count>\d+)\|([^\|\$%\.0-9])*(?<price>[0-9]+(\.[0-9]+)?)\$";

            double income = 0.0;
            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                MatchCollection matches = Regex.Matches(input, regex);
                foreach (Match match in matches)
                {
                    var customer = match.Groups["name"].Value;
                    var product = match.Groups["product"].Value;
                    var count = match.Groups["count"].Value;
                    var price = match.Groups["price"].Value;

                    Console.WriteLine($"{customer}: {product} - {int.Parse(count) * double.Parse(price):f2}");
                    income += int.Parse(count) * double.Parse(price);
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
