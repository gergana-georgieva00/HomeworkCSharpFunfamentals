using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] splitCommand = command.Split(' ');
                int value = int.Parse(splitCommand[1]);

                if (command.Contains("Add"))
                {
                    numbers.Add(value);
                }
                else if (command.Contains("Remove"))
                {
                    if (numbers.Contains(value))
                    {
                        numbers.Remove(value);
                    }
                }
                else if (command.Contains("Replace"))
                {
                    int replacement = int.Parse(splitCommand[2]);
                    if (numbers.Contains(value))
                    {
                        numbers[numbers.IndexOf(value)] = replacement;
                    }
                }
                else
                {
                    numbers.RemoveAll(x => x < value);
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
