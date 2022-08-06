using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdAstra2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(#|\|)(?<itemName>[a-zA-Z\s]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>[0-9]{1,5})\1";
            MatchCollection matches = Regex.Matches(input, regex);

            List<Item> items = new List<Item>();
            int caloriesTotal = 0;

            foreach (Match match in matches)
            {
                var name = match.Groups["itemName"].Value;
                var expDate = match.Groups["expirationDate"].Value;
                var calories = int.Parse(match.Groups["calories"].Value);

                caloriesTotal += calories;

                Item item = new Item(name, expDate, calories);
                items.Add(item);
            }

            Console.WriteLine($"You have food to last you for: {caloriesTotal / 2000} days!");

            if (items.Count == 0)
            {
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.ExprirationDate}, Nutrition: {item.Calories}");
            }
        }
    }

    class Item
    {
        public Item(string name, string expDate, int calories)
        {
            this.Name = name;
            this.ExprirationDate = expDate;
            this.Calories = calories;
        }

        public string Name { get; set; }
        public string ExprirationDate { get; set; }
        public int Calories { get; set; }
    }
}
