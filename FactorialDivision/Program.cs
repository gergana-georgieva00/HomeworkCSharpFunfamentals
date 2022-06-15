using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double result = DivideFactoriels(num1, num2);
            Console.WriteLine($"{result:f2}");
        }

        static double CalculateFactorial(double number)
        {
            double factoriel = 1;

            for (double i = number; i > 0; i--)
            {
                factoriel *= i;
            }

            return factoriel;
        }

        static double FactorialNum1(double number)
        {
            double factorielNum1 = CalculateFactorial(number);
            return factorielNum1;
        }

        static double FactorialNum2(double number)
        {
            double factorielNum2 = CalculateFactorial(number);
            return factorielNum2;
        }

        static double DivideFactoriels(double n1, double n2)
        {
            double result = (double) FactorialNum1(n1) / (double)FactorialNum2(n2);
            return result;
        }
    }
}
