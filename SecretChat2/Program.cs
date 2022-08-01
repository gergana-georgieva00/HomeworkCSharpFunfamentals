using System;

namespace SecretChat2
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] split = command.Split(":|:");
                bool error = false;

                if (command.Contains("InsertSpace"))
                {
                    int index = int.Parse(split[1]);

                    concealedMessage = concealedMessage.Insert(index, " ");
                }
                else if (command.Contains("Reverse"))
                {
                    string substring = split[1];

                    if (concealedMessage.Contains(substring))
                    {
                        int indexOfSubstring = concealedMessage.IndexOf(substring);
                        concealedMessage = concealedMessage.Remove(indexOfSubstring, substring.Length);
                        char[] reversed = substring.ToCharArray();
                        Array.Reverse(reversed);

                        string newStr = new string(reversed);
                        concealedMessage = concealedMessage + newStr;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        error = true;
                    }
                }
                else
                {
                    string substring = split[1];
                    string replacement = split[2];

                    if (concealedMessage.Contains(substring))
                    {
                        concealedMessage = concealedMessage.Replace(substring, replacement);
                    }
                }

                if (!error)
                {
                    Console.WriteLine(concealedMessage);
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
