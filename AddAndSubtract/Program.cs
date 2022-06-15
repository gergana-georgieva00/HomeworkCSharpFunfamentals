using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(num1, num2, num3));
        }

        static int SumOfTheFirstTwo(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }

        static int Subtract(int num1, int num2, int num3)
        {
            int result = SumOfTheFirstTwo(num1, num2) - num3;
            return result;
        }
    }
}
