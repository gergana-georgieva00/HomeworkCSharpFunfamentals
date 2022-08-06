using System;

namespace TheImitationGame2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] splCommand = command.Split('|');

                if (command.Contains("Move"))
                {
                    int numOfLetters = int.Parse(splCommand[1]);

                    string substrongToMove = message.Substring(0, numOfLetters);
                    message = message.Remove(0, numOfLetters);
                    message += substrongToMove;
                }
                else if(command.Contains("Insert"))
                {
                    int index = int.Parse(splCommand[1]);
                    string value = splCommand[2];

                    message = message.Insert(index, value);
                }
                else
                {
                    string substring = splCommand[1];
                    string replacement = splCommand[2];

                    message = message.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
