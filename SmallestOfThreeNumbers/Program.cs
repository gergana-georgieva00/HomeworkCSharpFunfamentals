using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            nums.Add(num1);
            nums.Add(num2);
            nums.Add(num3);

            Console.WriteLine(FindSmallestNumber(nums));
        }

        static int FindSmallestNumber(List<int> nums)
        {
            return nums.Min();
        }
    }
}
