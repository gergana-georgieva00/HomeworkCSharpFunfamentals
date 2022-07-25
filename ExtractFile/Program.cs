using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int startIndex = input.LastIndexOf('\\') + 1;
            string cut = input.Substring(startIndex);

            string fileName = cut.Split('.')[0];
            string extension = cut.Split('.')[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
