using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string number = num.ToString();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currNum = int.Parse(number[i].ToString());
                int currFibonachi = 1;
                for (int j = 1; j <= currNum; j++)
                {
                    currFibonachi = currFibonachi * j;
                }

                sum += currFibonachi;
            }

            string result = (sum == num) ? "yes" : "no";
            Console.WriteLine(result);
        }
    }
}
