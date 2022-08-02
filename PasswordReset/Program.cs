using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] spltCommand = command.Split();

                if (command.Contains("TakeOdd"))
                {
                    StringBuilder oddChars = new StringBuilder();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            oddChars.Append(input[i]);
                        }
                    }

                    input = oddChars.ToString();
                    Console.WriteLine(input);
                }
                else if (command.Contains("Cut"))
                {
                    int index = int.Parse(spltCommand[1]);
                    int length = int.Parse(spltCommand[2]);

                    string substring = input.Substring(index, length);
                    input = input.Remove(input.IndexOf(substring), length);
                    Console.WriteLine(input);
                }
                else
                {
                    string substring = spltCommand[1];
                    string substitute = spltCommand[2];

                    if (input.Contains(substring))
                    {
                        input = input.Replace(substring, substitute);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {input}");
        }
    }
}
