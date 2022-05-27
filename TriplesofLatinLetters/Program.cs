using System;

namespace TriplesofLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int first = 97; first < 97 + n; first++)
            {
                char firstChar = (char)first;
                for (int second = 97; second < 97 + n; second++)
                {
                    char secondChar = (char)second;
                    for (int third = 97; third < 97 + n; third++)
                    {
                        char thirdChar = (char)third;
                        Console.Write(firstChar);
                        Console.Write(secondChar);
                        Console.WriteLine(thirdChar);
                    }
                }
            }
        }
    }
}
