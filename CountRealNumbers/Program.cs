using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            numbers.Sort();

            Dictionary<double, int> numsWithOccurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (numsWithOccurrences.ContainsKey(number))
                {
                    numsWithOccurrences[number] += 1;
                }
                else
                {
                    numsWithOccurrences.Add(number, 1);
                }
            }

            foreach (var currPair in numsWithOccurrences)
            {
                Console.WriteLine($"{currPair.Key} -> {currPair.Value}");
            }
        }
    }
}
