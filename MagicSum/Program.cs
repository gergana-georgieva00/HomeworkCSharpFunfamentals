using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i <= arr.Length - 2; i++)
            {
                int currNumOuter = arr[i];
                int currSum = 0;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    int currNumInner = arr[j];
                    currSum = currNumOuter + currNumInner;

                    if (currSum == number)
                    {
                        Console.Write(currNumOuter + " " + currNumInner);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
