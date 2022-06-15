using System;
using System.Linq;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                Console.WriteLine(IsPalindrome(command).ToString().ToLower());
            }
        }

        static bool IsPalindrome(string command)
        {
            return command.SequenceEqual(command.Reverse());
        }
    }
}
