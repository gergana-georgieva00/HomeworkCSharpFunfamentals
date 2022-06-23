using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            List<int> currentState = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int index = 0;
            
            while (peopleWaiting > 0)
            {
                if (index >= currentState.Count)
                {
                    break;
                }

                if (currentState[index] < 4)
                {
                    currentState[index]++;
                    peopleWaiting--;
                }
                else
                {
                    index++;
                }
                
            }

            if (peopleWaiting <= 0)
            {
                if (currentState[currentState.Count - 1] < 4)
                {
                    Console.WriteLine("The lift has empty spots!");
                }
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
            }

            Console.WriteLine(string.Join(' ', currentState));
        }
    }
}
