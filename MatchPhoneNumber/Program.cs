using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();

            Regex regex = new Regex(@"\+359( |-)2\1(\d){3}\1(\d){4}\b");

            MatchCollection matches = regex.Matches(phones);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
