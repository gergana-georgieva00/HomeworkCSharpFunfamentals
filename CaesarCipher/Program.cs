using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Convert.ToChar(input[i] + 3);
            }

            foreach (var character in input)
            {
                Console.Write(character);
            }
        }
    }
}
