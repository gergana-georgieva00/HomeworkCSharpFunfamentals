using System;
using System.Linq;
using System.Text;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            string result = "";

            foreach (var word in arr)
            {
                int length = word.Length;
                result += string.Concat((Enumerable.Repeat(word, length)));
            }

            Console.WriteLine(result);
        }
    }
}
