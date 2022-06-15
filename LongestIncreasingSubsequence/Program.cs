using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> currentLongestSubsequence = new List<int>();
            List<int> longestSubsequence = new List<int>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                int currFirstelement = input[i];
                currentLongestSubsequence.Add(currFirstelement);

                while (true)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (input[j] > currentLongestSubsequence[currentLongestSubsequence.Count - 1])
                        {
                            currentLongestSubsequence.Add(input[j]);
                        }

                        if (currentLongestSubsequence.Count > longestSubsequence.Count)
                        {
                            longestSubsequence = currentLongestSubsequence;
                        }
                    }
                }
            }
        }
    }
}
