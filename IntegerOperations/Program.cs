using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNum = int.Parse(Console.ReadLine());
            long secondNum = int.Parse(Console.ReadLine());
            long thirdNum = int.Parse(Console.ReadLine());
            long fourthNum = int.Parse(Console.ReadLine());

            long sum = firstNum + secondNum;
            int divide = (int)sum / (int)thirdNum;
            int multiply = divide * (int)fourthNum;

            Console.WriteLine(multiply);
        }
    }
}
