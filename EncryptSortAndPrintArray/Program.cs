using System;
using System.Collections.Generic;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> strings = new List<string>();
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                strings.Add(input);
            }

            List<int> outputSums = new List<int>();
            foreach (var inputString in strings)
            {
                int currSum = 0;
                for (int i = 0; i < inputString.Length; i++)
                {
                    int currLength = inputString.Length;
                    int codeCurrElement = (int)inputString[i];

                    if (inputString[i].ToString().ToLower() == "a" || inputString[i].ToString().ToLower() == "e" || inputString[i].ToString().ToLower() == "i" 
                        || inputString[i].ToString().ToLower() == "o" || inputString[i].ToString().ToLower() == "u")
                    {
                        currSum += codeCurrElement * currLength;
                    }
                    else
                    {
                        currSum += codeCurrElement / currLength;
                    }
                }

                outputSums.Add(currSum);
            }

            List<int> output = outputSums.OrderBy(n => n).ToList();

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
