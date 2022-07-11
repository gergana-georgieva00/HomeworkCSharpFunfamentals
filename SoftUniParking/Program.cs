using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkedCars = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string username = command[1];

                if (command[0] == "register")
                {
                    string licensePlateNumber = command[2];

                    if (parkedCars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkedCars[username]}");
                    }
                    else
                    {
                        parkedCars.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else
                {
                    if (parkedCars.ContainsKey(username))
                    {
                        parkedCars.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var pair in parkedCars)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
