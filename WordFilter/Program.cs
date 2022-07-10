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

            Console.WriteLine(string.Join(Environment.NewLine, arr));
        }
    }
}
