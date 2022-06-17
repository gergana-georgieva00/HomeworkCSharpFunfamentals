using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitCommand = command.Split(' ');
                // add the given number to the end of the list
                if (command.Contains("Add"))
                {
                    integers.Add(int.Parse(splitCommand[1]));
                }
                // insert the number at the given index
                else if (command.Contains("Insert"))
                {
                    if ((int.Parse(splitCommand[2]) > integers.Count - 1) || int.Parse(splitCommand[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        integers.Insert(int.Parse(splitCommand[2]), int.Parse(splitCommand[1]));
                    }
                }
                // remove the number at the given index
                else if (command.Contains("Remove"))
                {
                    if ((int.Parse(splitCommand[1]) > integers.Count - 1) || int.Parse(splitCommand[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        integers.RemoveAt(int.Parse(splitCommand[1]));
                    }
                   
                }
                // first number becomes last. This has to be repeated the specified number of times
                else if (command.Contains("left"))
                {
                    for (int i = 0; i < int.Parse(splitCommand[2]); i++)
                    {
                        int movingInt = integers[0];
                        integers.RemoveAt(0);
                        integers.Add(movingInt);
                    }
                }
                // last number becomes first. To be repeated the specified number of times
                else if (command.Contains("right"))
                {
                    for (int i = 0; i < int.Parse(splitCommand[2]); i++)
                    {
                        int lastIndex = integers.Count - 1;
                        int movingInt = integers[lastIndex];
                        integers.RemoveAt(lastIndex);
                        integers.Insert(0, movingInt);
                    }
                }
            }

            Console.WriteLine(string.Join(' ', integers));
        }
    }
}
