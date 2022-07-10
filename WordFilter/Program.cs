using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                            .Split()
                            .Where(w => w.Length % 2 == 0)
                            .ToArray();

            foreach (var word in arr)
            {
                Console.WriteLine(word);
            }
        }
    }
}
