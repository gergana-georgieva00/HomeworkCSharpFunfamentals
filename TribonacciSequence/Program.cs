using System;
using System.Collections.Generic;
using System.Text;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string output = "";
            if (num == 2)
            {
                output = "1 1";
            }
            else if (num == 1)
            {
                output = "1";
            }
            else
            {
                output = string.Join(" ", (FindTribonacciSequence(num).ToArray()));
            }
            
            Console.WriteLine(output);
        }

        static List<int> FindTribonacciSequence(int num)
        {
            List<int> tribonacci = new List<int>();
            tribonacci.Add(1);
            tribonacci.Add(1);
            tribonacci.Add(2);

            int sumPrevThree = 4;

            for (int i = 3; i < num; i++)
            {
                tribonacci.Add(sumPrevThree);
                sumPrevThree = tribonacci[i] + tribonacci[i - 1] + tribonacci[i - 2];
            }

            return tribonacci;
        }
    }
}
