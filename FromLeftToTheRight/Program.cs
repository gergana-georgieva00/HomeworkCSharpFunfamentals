using System;
using System.Collections.Generic;
using System.Linq;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] splInput = input.Split(' ');
                long leftNum = long.Parse(splInput[0]);
                long rightNum = long.Parse(splInput[1]);

                long sum = 0;
                if (leftNum > rightNum)
                {
                    sum = GetSum(leftNum);
                }
                else
                {
                    sum = GetSum(rightNum);
                }
                
                Console.WriteLine(sum);
            }
            
        }

        static int GetSum(long greaterNumber)
        {
            int sum = 0;
            
            while (greaterNumber != 0)
            {
                sum += (int)(greaterNumber % 10);
                greaterNumber /= 10;
            }

            return Math.Abs(sum);
        }
    }
}
