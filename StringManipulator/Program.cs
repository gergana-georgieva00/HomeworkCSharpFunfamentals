using System;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splCommand = command.Split();

                if (command.Contains("Translate"))
                {
                    char ch = char.Parse(splCommand[1]);
                    char replacement = char.Parse(splCommand[2]);

                    input = input.Replace(ch, replacement);
                    Console.WriteLine(input);
                }
                else if (command.Contains("Includes"))
                {
                    string substring = splCommand[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command.Contains("Start"))
                {
                    string substring = splCommand[1];

                    if (input.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command.Contains("Lowercase"))
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command.Contains("FindIndex"))
                {
                    char ch = char.Parse(splCommand[1]);

                    int index = input.LastIndexOf(ch);
                    Console.WriteLine(index);
                }
                else
                {
                    int startIndex = int.Parse(splCommand[1]);
                    int count = int.Parse(splCommand[2]);

                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }
            }
        }
    }
}
