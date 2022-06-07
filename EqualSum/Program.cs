using System;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(input, int.Parse);

            if (arr.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }

            bool sum = false;
            for (int i = 0; i < arr.Length; i++)
            {
                int currElement = arr[i];

                // sum left
                int sumLeft = 0;
                for (int j = 0; j < i; j++)
                {
                    sumLeft += arr[j];
                }

                // sum right
                int sumRight = 0;
                for (int k = i + 1; k < arr.Length; k++)
                {

                    sumRight += arr[k];
                }

                if (sumLeft == sumRight)
                {
                    sum = true;
                    Console.WriteLine(i);
                    break;
                }
            }

            if (sum == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
