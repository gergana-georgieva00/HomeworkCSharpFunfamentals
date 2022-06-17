using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int maxCapacityPerWagon = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command.Contains("Add"))
                {
                    string[] splitCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int addToTheWagons = int.Parse(splitCommand[1]);
                    wagons.Add(addToTheWagons);
                }
                else
                {
                    int commandInt = int.Parse(command);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currWagon = wagons[i];

                        if (currWagon + commandInt <= maxCapacityPerWagon)
                        {
                            wagons[i] += commandInt;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(' ', wagons));
        }
    }
}
