using System;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                Console.Write($"{command} = ");
                char[] arr = command.ToCharArray();
                Array.Reverse(arr);
                Console.WriteLine($"{new string(arr)}");
            }
        }
    }
}
