using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                List<string> splitCommand = command.Split(' ').ToList();
                int index = int.Parse(splitCommand[1].ToString());

                if (command.Contains("Shoot"))
                {
                    int power = int.Parse(splitCommand[2].ToString());

                    if (index < targets.Count && index >= 0)
                    {
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (command.Contains("Add"))
                {
                    int value = int.Parse(splitCommand[2].ToString());

                    if (index < targets.Count && index >= 0)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else
                {
                    int radius = int.Parse(splitCommand[2].ToString());
                    bool targetMissed = false;
                    if (index < targets.Count && index >= 0)
                    {
                        if (index + radius < targets.Count && index - radius >= 0)
                        {
                            int count = 2 * radius + 1;
                            int startingIndex = index - radius;
                            targets.RemoveRange(startingIndex, count);
                        }
                        else
                        {
                            targetMissed = true;
                        }
                    }
                    else
                    {
                        if (index >= 0)
                        {
                            targetMissed = true;
                        }
                    }

                    if (targetMissed)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}
