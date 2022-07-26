using System;
using System.Linq;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                if (command.Contains("Move"))
                {
                    int numOfLetters = int.Parse(command.Split('|')[1]);

                    string substringToMove = message.Substring(0, numOfLetters);
                    message = message.Remove(0, numOfLetters);
                    message = message + substringToMove;
                }
                else if (command.Contains("Insert"))
                {
                    int index = int.Parse(command.Split('|')[1]);
                    string value = command.Split('|')[2];

                    message = message.Insert(index, value);
                }
                else
                {
                    string substring = command.Split('|')[1];
                    string replacement = command.Split('|')[2];

                    message = message.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
