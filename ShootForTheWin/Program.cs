using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int counter = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);

                if (index >= targets.Count)
                {
                    continue;
                }

                int currentValue = targets[index];
                targets[index] = -1;
                counter++;

                for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i] != -1)
                    {
                        if (targets[i] > currentValue)
                        {
                            targets[i] -= currentValue;
                        }
                        else
                        {
                            targets[i] += currentValue;
                        }
                    }
                }
            }

            Console.WriteLine($"Shot targets: {counter} -> {string.Join(' ', targets)}");
        }
    }
}
