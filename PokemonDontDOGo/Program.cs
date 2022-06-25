using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> integers = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            long sum = 0;
            while (integers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                bool toBreak = true;
                long elementToDelete;
                if (index < 0)
                {
                    elementToDelete = integers[0];
                    index = 0;
                    toBreak = false;
                }
                else if (index >= integers.Count)
                {
                    elementToDelete = integers[integers.Count - 1];
                    index = integers.Count - 1;
                    toBreak = false;
                }
                else
                {
                    elementToDelete = integers[index];
                }
                
                sum += elementToDelete;

                integers.RemoveAt(index);
                for (int i = 0; i < integers.Count; i++)
                {
                    if (integers[i] <= elementToDelete)
                    {
                        integers[i] += elementToDelete;
                    }
                    else
                    {
                        integers[i] -= elementToDelete;
                    }
                }

                if (toBreak)
                {
                    continue;
                }

                if (index >= integers.Count)
                {
                    integers.Add(integers[0]);
                }
                else
                {
                    integers.Insert(0, integers[integers.Count - 1]);
                }
            }

            Console.WriteLine(sum);
        }
    }
}
