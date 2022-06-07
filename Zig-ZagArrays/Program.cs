using System;
using System.Collections.Generic;

namespace Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> red = new List<int>();
            List<int> blue = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string[] arrString = input.Split(' ');

                int[] arrInt = Array.ConvertAll(arrString, int.Parse);

                if (i % 2 == 0)
                {
                    blue.Add(arrInt[0]);
                    red.Add(arrInt[1]);
                }
                else
                {
                    red.Add(arrInt[0]);
                    blue.Add(arrInt[1]);
                }
            }

            foreach (var item in red)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            foreach (var item in blue)
            {
                Console.Write(item + " ");
            }
        }
    }
}
