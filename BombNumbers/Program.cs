using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] numAndPower = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int number = numAndPower[0];
            int power = numAndPower[1];

            while (numbers.Contains(number))
            {
                int indexOfNum = numbers.IndexOf(number);
                int startingIndex = indexOfNum - power;
                int count = 2 * power + 1;

                if (startingIndex < 0)
                {
                    startingIndex = 0;

                    int beforeNum = 0;
                    for (int i = 0; i < indexOfNum; i++)
                    {
                        beforeNum++;
                    }

                    count = power + 1 + beforeNum;
                }

                if (startingIndex + count > numbers.Count)
                {
                    count = (numbers.Count - 1) - startingIndex + 1;
                }
                
                numbers.RemoveRange(startingIndex, count);
            }

            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
