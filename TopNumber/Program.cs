using System;
using System.Linq;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            IsTopNumber(n);
        }

        static void IsTopNumber(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (SumOfDigitsDivisibleByEight(i) && OneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool SumOfDigitsDivisibleByEight(int n)
        {
            bool divisible = false;
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            if (sum % 8 == 0)
            {
                divisible = true;
            }

            return divisible;
        }

        static bool OneOddDigit(int n)
        {
            bool hasOddDigit = false;
            int countOdd = n.ToString().Select(x => x - '0').Count(x => x % 2 != 0);
            if (countOdd > 0)
            {
                hasOddDigit = true;
            }

            return hasOddDigit;
        }
    }
}
