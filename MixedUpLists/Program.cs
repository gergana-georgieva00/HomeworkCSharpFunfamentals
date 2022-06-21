using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> connected = new List<int>();
            List<int> constrains = new List<int>();
            while (true)
            {
                connected.Add(firstList[0]);
                connected.Add(secondList.Last());

                firstList.Remove(firstList[0]);
                secondList.Remove(secondList.Last());

                if (firstList.Count == 0 || secondList.Count == 0)
                {
                    if (firstList.Count == 0)
                    {
                        constrains.Add(secondList[0]);
                        constrains.Add(secondList[1]);
                    }
                    else
                    {
                        constrains.Add(firstList[0]);
                        constrains.Add(firstList[1]);
                    }

                    constrains.Sort();

                    break;
                }
            }

            List<int> result = new List<int>();
            foreach (var num in connected)
            {
                if (num > constrains[0] && num < constrains[1])
                {
                    result.Add(num);
                }
            }

            result.Sort();
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
