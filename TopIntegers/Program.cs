using System;
using System.Collections.Generic;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int[] arr = Array.ConvertAll(input, int.Parse);

            List<int> topIntegers = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int currElement = arr[i];
                bool toContinue = false;

                if (i == arr.Length - 1)
                {
                    topIntegers.Add(currElement);
                    break;
                }

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currElement > arr[j])
                    {
                        toContinue = true;
                    }
                    else
                    {
                        toContinue = false;
                        break;
                    }
                }

                if (toContinue == true)
                {
                    topIntegers.Add(currElement);
                }
            }

            foreach (var item in topIntegers)
            {
                Console.Write(item + " ");
            }
        }
    }
}
