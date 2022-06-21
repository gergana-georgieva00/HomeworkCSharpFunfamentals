using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int middleIndex = (input.Count - 1) / 2;

            // calculate left sum
            double sumLeft = 0;
            for (int i = 0; i < middleIndex; i++)
            {
                if (input[i] == 0)
                {
                    sumLeft -= sumLeft * 0.2;
                }
                else
                {
                    sumLeft += (double)input[i];
                }
            }

            // calculate right sum
            double sumRight = 0;
            for (int i = input.Count - 1; i > middleIndex; i--)
            {
                if (input[i] == 0)
                {
                    sumRight -= sumRight * 0.2;
                }
                else
                {
                    sumRight += (double)input[i];
                }
            }

            if (sumLeft > sumRight)
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
        }
    }
}
