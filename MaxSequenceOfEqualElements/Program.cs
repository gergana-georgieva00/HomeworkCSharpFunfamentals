using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> currLongestSequence = new List<int>();
            List<int> longestSequence = new List<int>();
            int prevElement = arr[0];
            currLongestSequence.Add(prevElement);

            for (int i = 1; i <= arr.Length - 1; i++)
            {
                int currElement = arr[i];
                if (prevElement == currElement)
                {
                    currLongestSequence.Add(currElement);
                }
                else
                {
                    currLongestSequence = new List<int>();
                    currLongestSequence.Add(currElement);
                }

                if (currLongestSequence.Count > longestSequence.Count)
                {
                    longestSequence = currLongestSequence;
                }

                prevElement = currElement;
            }

            foreach (var item in longestSequence)
            {
                Console.Write(item + " ");
            }
        }
    }
}
