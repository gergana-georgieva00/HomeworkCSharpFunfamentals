using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(number));
        }

        static int GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }
        }
    }
}
