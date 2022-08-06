using System;

namespace SecretChat2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] splCommand = command.Split(":|:");

                if (command.Contains("Insert"))
                {
                    message = message.Insert(int.Parse(splCommand[1]), " ");
                    Console.WriteLine(message);
                }
                else if (command.Contains("Reverse"))
                {
                    string substring = splCommand[1];
                    if (message.Contains(substring))
                    {
                        char[] reversed = substring.ToCharArray();
                        Array.Reverse(reversed);
                        string newStr = new string(reversed);
                        message = message.Remove(message.IndexOf(substring), substring.Length);
                        message += newStr;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    message = message.Replace(splCommand[1], splCommand[2]);
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
