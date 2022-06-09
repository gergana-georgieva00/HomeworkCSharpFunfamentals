using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jaggedArray[i] = new int[i + 1];
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (col == 0 || col == row)
                    {
                        jaggedArray[row][col] = 1;
                    }
                    else
                    {
                        jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
