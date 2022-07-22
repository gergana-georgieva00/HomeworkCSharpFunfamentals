using System;
using System.Collections.Generic;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dwarves = new Dictionary<string, Dictionary<string, long>>();

            string input;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string dwarfName = input.Split(" <:> ")[0];
                string dwarfHatColor = input.Split(" <:> ")[1];
                long dwarfPhysics = long.Parse(input.Split(" <:> ")[2]);

                if (!dwarves.ContainsKey(dwarfHatColor))
                {
                    dwarves.Add(dwarfHatColor, new Dictionary<string, long>());
                    dwarves[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                }
                else
                {
                    if (dwarves[dwarfHatColor].ContainsKey(dwarfName))
                    {
                        if (dwarves[dwarfHatColor][dwarfName] < dwarfPhysics)
                        {
                            dwarves[dwarfHatColor][dwarfName] = dwarfPhysics;
                        }
                    }
                    else
                    {
                        dwarves[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                    }
                }
            }

            // order the dwarfs by physics in descending order
            // and then by the total count of dwarfs with the same hat color in descending order.
            // If all sorting criteria fail, the order should be by order of input.


        }
    }
}
