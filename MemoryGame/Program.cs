using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ').ToList();

            int moves = 0;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                List<int> indexes = command.Split(' ').Select(int.Parse).ToList();

                if (indexes[0] == indexes[1] || (indexes[0] >= elements.Count || indexes[1] >= elements.Count) ||
                    (indexes[0] < 0 || indexes[1] < 0))
                {
                    moves++;
                    elements.Insert(elements.Count / 2, $"-{moves}a");
                    elements.Insert((elements.Count - 1) / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (elements[indexes[0]] == elements[indexes[1]])
                {
                    moves++;
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[indexes[0]]}!");
                    string elementToRemove = elements[indexes[0]];
                    elements.Remove(elementToRemove);
                    elements.Remove(elementToRemove);

                    if (elements.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', elements));
        }   
            
    }
}
