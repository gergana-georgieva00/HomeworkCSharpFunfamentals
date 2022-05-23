using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string reverseUsername = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                reverseUsername += username[i];
            }

            int tries = 0;
            while (true)
            {
                tries++;
                string pass = Console.ReadLine();
                if (pass == reverseUsername)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    if (tries == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect password. Try again.");
                        continue;
                    }
                }
            }
        }
    }
}
