using System;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (var username in usernames)
            {
                bool validLength = false;
                bool validChars = true;

                if (username.Length >= 3 && username.Length <= 16)
                {
                    validLength = true;
                }
                else
                {
                    continue;
                }

                foreach (var currChar in username)
                {
                    if (!Char.IsLetterOrDigit(currChar) && currChar != '-' && currChar != '_')
                    {
                        validChars = false;
                        break;
                    }
                }
                

                if (validLength && validChars)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}
