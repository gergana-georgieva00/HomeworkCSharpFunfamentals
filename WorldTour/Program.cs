using System;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] splitCommand = command.Split(':');

                if (command.Contains("Add"))
                {
                    int index = int.Parse(splitCommand[1]);
                    string str = splitCommand[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, str);
                    }
                }
                else if (command.Contains("Remove"))
                {
                    int startIndex = int.Parse(splitCommand[1]);
                    int endIndex = int.Parse(splitCommand[2]);

                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else
                {
                    string oldStr = splitCommand[1];
                    string newStr = splitCommand[2];

                    if (stops.Contains(oldStr))
                    {
                        stops = stops.Replace(oldStr, newStr);
                    }
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
