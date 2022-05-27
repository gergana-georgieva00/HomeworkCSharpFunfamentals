using System;

namespace DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char currLetter = char.Parse(Console.ReadLine());
                int asciiCodeLetter = (int)currLetter + key;
                Console.Write((char)asciiCodeLetter);
            }
        }
    }
}
