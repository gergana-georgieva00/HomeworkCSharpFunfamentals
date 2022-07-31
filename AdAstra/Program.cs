using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(#|\|)(?<name>[a-zA-Z ]+)\1(?<expDate>\d{2}/\d{2}/\d{2})\1(?<calories>[0-9]{1,5})\1";

            int totalCalories = 0;
            //Dictionary<string, Dictionary<string, int>> output = new Dictionary<string, Dictionary<string, int>>();

            MatchCollection matches = Regex.Matches(input, regex);
            foreach (Match match in matches)
            {
                var calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;

                var expirationDate = match.Groups["expDate"].Value;
                var itemName = match.Groups["name"].Value;

                //if (!output.ContainsKey(itemName))
                //{
                //    output.Add(itemName, new Dictionary<string, int>());
                //    output[itemName].Add(expirationDate, calories);
                //}
                //else
                //{
                //    if (!output[itemName].ContainsKey(expirationDate))
                //    {
                //        output[itemName].Add(expirationDate, calories);
                //    }
                //}
                
            }

            int foodForHowManyDays = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {foodForHowManyDays} days!");

            //if (output.Count > 0)
            //{
            //    foreach (var pair in output)
            //    {
            //        foreach (var pair2 in pair.Value)
            //        {
            //            Console.WriteLine($"Item: {pair.Key}, Best before: {pair2.Key}, Nutrition: {pair2.Value}");
            //        }
            //    }
            //}

            if (foodForHowManyDays > 0)
            {
                foreach (Match match in matches)
                {
                    var calories = int.Parse(match.Groups["calories"].Value);
                    var expirationDate = match.Groups["expDate"].Value;
                    var itemName = match.Groups["name"].Value;

                    Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {calories}");
                }
            }
        } 
    }
}
