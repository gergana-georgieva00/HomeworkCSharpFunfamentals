using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] splCommand = command.Split(">>>");

                if (command.Contains("Contains"))
                {
                    if (input.Contains(splCommand[1]))
                    {
                        Console.WriteLine($"{input} contains {splCommand[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command.Contains("Flip"))
                {
                    int startIndex = int.Parse(splCommand[2]);
                    int endIndex = int.Parse(splCommand[3]);

                    string substring = input.Substring(startIndex, endIndex - startIndex);

                    if (splCommand[1] == "Upper")
                    {
                        input = input.Remove(startIndex, endIndex - startIndex);

                        if (startIndex >= input.Length)
                        {
                            input = input + substring;
                        }
                        else
                        {
                            input = input.Insert(startIndex, substring.ToUpper());
                        }
                    }
                    else
                    {
                        input = input.Remove(startIndex, endIndex - startIndex);

                        if (startIndex >= input.Length)
                        {
                            input = input + substring;
                        }
                        else
                        {
                            input = input.Insert(startIndex, substring.ToLower());
                        }
                    }

                    Console.WriteLine(input);
                }
                else
                {
                    int startIndex = int.Parse(splCommand[1]);
                    int endIndex = int.Parse(splCommand[2]);

                    input = input.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(input);
                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
