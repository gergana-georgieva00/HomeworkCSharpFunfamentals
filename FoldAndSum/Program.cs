using System;
using System.Collections.Generic;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> middle = new List<int>();
            for (int i = (input.Length / 2) / 2; i < input.Length - ((input.Length / 2) / 2); i++)
            {
                middle.Add(input[i]);
            }

            List<int> left = new List<int>();
            for (int i = 0; i < (input.Length / 2) / 2; i++)
            {
                left.Add(input[i]);
            }

            List<int> right = new List<int>();
            for (int i = input.Length - ((input.Length / 2) / 2); i < input.Length; i++)
            {
                right.Add(input[i]);
            }

            left.Reverse();
            right.Reverse();

            List<int> leftAndRight = new List<int>();
            foreach (var item in left)
            {
                leftAndRight.Add(item);
            }

            foreach (var item in right)
            {
                leftAndRight.Add(item);
            }

            int[] result = new int[middle.Count];
            for (int i = 0; i < middle.Count; i++)
            {
                result[i] = leftAndRight[i] + middle[i];
            }

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
