using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] splitCommand = command.Split(' ');

                // delete
                if (splitCommand.Length == 2)
                {
                    input.RemoveAll(item => item == int.Parse(splitCommand[1]));
                }
                // insert
                else
                {
                    input.Insert(int.Parse(splitCommand[2]), int.Parse(splitCommand[1]));
                }
            }

            Console.WriteLine(string.Join(' ', input));
        }
    }
}
