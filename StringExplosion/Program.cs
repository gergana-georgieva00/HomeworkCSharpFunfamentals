using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // collect the indexes of all bombs
            List<int> indexesOfBombs = new List<int>();
            List<int> countOfCharsToDelete = new List<int>();
            List<string> substrings = input.Split('>').ToList();
            substrings.RemoveAt(0);

            for (int i = 0; i < input.Length; i++)
            {
                
                if (input[i] == '>')
                {
                    indexesOfBombs.Add(i);
                    countOfCharsToDelete.Add(int.Parse(input[i + 1].ToString()));
                }
            }

            // start deleting
            int remainder = 0;

            for (int i = 0; i < indexesOfBombs.Count; i++)
            {
                string substringToDelete;
                int countToDelete;
                if (countOfCharsToDelete[i] > substrings[i].Length)
                {
                    countToDelete = substrings[i].Length;
                    remainder = countOfCharsToDelete[i] - substrings[i].Length;

                    if (i + 1 < countOfCharsToDelete.Count)
                    {
                        countOfCharsToDelete[i + 1] += remainder;
                    }
                    
                    remainder = 0;
                }
                else
                {
                    countToDelete = countOfCharsToDelete[i];
                }

                substringToDelete = substrings[i].Substring(0, countToDelete);

                input = input.Remove(input.IndexOf(substringToDelete), countToDelete);
            }

            Console.WriteLine(input);
        }
    }
}
