using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            string output = FindMultiplicationSign(num1, num2, num3);
            Console.WriteLine(output);
        }

        static string FindMultiplicationSign(int num1, int num2, int num3)
        {
            string output = "";
            int negativeCounter = 0;

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                output = "zero";
                return output;
            }

            if (num1 < 0)
            {
                negativeCounter++;
            }

            if (num2 < 0)
            {
                negativeCounter++;
            }

            if (num3 < 0)
            {
                negativeCounter++;
            }

            if (negativeCounter == 1 || negativeCounter == 3)
            {
                output = "negative";
            }
            else
            {
                output = "positive";
            }

            return output;
        }
    }
}
