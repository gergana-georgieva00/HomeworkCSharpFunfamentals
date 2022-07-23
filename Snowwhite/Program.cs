using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            Dictionary<long, Dictionary<string, List<string>>> physicsColorName = new Dictionary<long, Dictionary<string, List<string>>>();

            foreach (var colorDic in dwarves)
            {
                foreach (var namePhy in colorDic.Value)
                {
                    if (physicsColorName.ContainsKey(namePhy.Value))
                    {
                        if (physicsColorName[namePhy.Value].ContainsKey(colorDic.Key))
                        {
                            physicsColorName[namePhy.Value][colorDic.Key].Add(namePhy.Key);
                        }
                        else
                        {
                            physicsColorName[namePhy.Value].Add(colorDic.Key, new List<string>());
                            physicsColorName[namePhy.Value][colorDic.Key].Add(namePhy.Key);
                        }
                    }
                    else
                    {
                        physicsColorName.Add(namePhy.Value, new Dictionary<string, List<string>>());
                        physicsColorName[namePhy.Value].Add(colorDic.Key, new List<string>());
                        physicsColorName[namePhy.Value][colorDic.Key].Add(namePhy.Key);
                    }

                    physicsColorName[namePhy.Value].OrderByDescending(x => x.Value.Count);
                }
            }

            physicsColorName = physicsColorName.OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value.Count)
                .ToDictionary(y => y.Key, y => y.Value));

            // print
            foreach (var phyDic in physicsColorName)
            {
                foreach (var colorName in phyDic.Value)
                {
                    foreach (var name in colorName.Value)
                    {
                        Console.WriteLine($"({colorName.Key}) {name} <-> {phyDic.Key}");
                    }
                }
            }
        }
    }
}
