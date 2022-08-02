using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string regex = @"(@#+)(?<barcode>[A-Z][a-zA-Z0-9]{4,}[A-Z])(@#+)";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, regex);

                if (matches.Count == 0)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    foreach (Match match in matches)
                    {
                        var validBarcode = match.Groups["barcode"].Value;

                        string poductGroup = "00";

                        if (validBarcode.Any(char.IsDigit))
                        {
                            StringBuilder sb = new StringBuilder();

                            foreach (var character in validBarcode)
                            {
                                if (Char.IsDigit(character))
                                {
                                    sb.Append(character);
                                }
                            }

                            poductGroup = sb.ToString();
                        }

                        Console.WriteLine($"Product group: {poductGroup}");
                    }
                }
            }
        }
    }
}
