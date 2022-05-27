using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string number = n.ToString();
            long sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currDigit = int.Parse(number[i].ToString());
                sum += currDigit;
            }

            Console.WriteLine(sum);
        }
    }
}
