using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal numberA = decimal.Parse(Console.ReadLine());
            decimal numberB = decimal.Parse(Console.ReadLine());

            decimal eps = 0.000001m;
            bool equal = false;

            decimal difference = Math.Abs(numberA - numberB);

            if (difference < eps)
            {
                equal = true;
            }

            Console.WriteLine(equal);
        }
    }
}
