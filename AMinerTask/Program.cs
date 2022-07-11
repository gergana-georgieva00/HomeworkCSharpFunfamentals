using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, long> resourceQuantity = new Dictionary<string, long>();

            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;
                long quantity = long.Parse(Console.ReadLine());

                if (resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] += quantity;
                }
                else
                {
                    resourceQuantity.Add(resource, quantity);
                }
            }

            foreach (var pair in resourceQuantity)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
