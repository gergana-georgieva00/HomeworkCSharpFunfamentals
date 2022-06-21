using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string text = Console.ReadLine();

            int[] sums = new int[numbers.Count];

            // calculate the sums
            int index = 0;

            foreach (var num in numbers)
            {
                int currNum = num;

                while (currNum != 0)
                {
                    sums[index] += currNum % 10;
                    currNum /= 10;
                }

                index++;
            }

            // find the char with corresponding index
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < sums.Length; i++)
            {
                // if index out of range
                if (sums[i] >= text.Length)
                {
                    sums[i] = (sums[i] - (text.Length - 1)) - 1;
                }
                // else
                output.Append(text[sums[i]]);
                text = text.Remove(sums[i], 1);
            }

            Console.WriteLine(output.ToString());
        }
    }
}
