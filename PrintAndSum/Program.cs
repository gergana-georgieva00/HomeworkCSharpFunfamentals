﻿using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = n1; i <= n2; i++)
            {
                sum += i;
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
