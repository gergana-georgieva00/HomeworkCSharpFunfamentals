using System;

namespace WorldTour2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] splCommand = command.Split(':');

                if (command.Contains("Add"))
                {
                    int index = int.Parse(splCommand[1]);
                    string str = splCommand[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, str);
                    }

                    Console.WriteLine(stops);
                }
                else if (command.Contains("Remove"))
                {
                    int startIndex = int.Parse(splCommand[1]);
                    int endIndex = int.Parse(splCommand[2]);

                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(stops);
                }
                else
                {
                    string oldStr = splCommand[1];
                    string newStr = splCommand[2];

                    if (stops.Contains(oldStr))
                    {
                        stops = stops.Replace(oldStr, newStr);
                    }

                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
