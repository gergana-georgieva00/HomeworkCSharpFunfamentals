using System;
using System.Collections.Generic;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] allStringsFromInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<double> allNumsFromInput = new List<double>();

            for (int i = 0; i < allStringsFromInput.Length; i++)
            {
                string currString = allStringsFromInput[i];

                char firstChar = currString[0];
                char secondChar = currString[currString.Length - 1];
                double currNum = double.Parse(currString.Substring(1, currString.Length - 2));

                int ch1PositionInAlphabet = (int)firstChar % 32;
                int ch2PositionInAlphabet = (int)secondChar % 32;

                allNumsFromInput.Add(currNum);

                // firstChar
                if (Char.IsUpper(firstChar))
                {
                    currNum /= (double)ch1PositionInAlphabet;
                }
                else
                {
                    currNum *= (double)ch1PositionInAlphabet;
                }

                // secondChar
                if (Char.IsUpper(secondChar))
                {
                    currNum -= (double)ch2PositionInAlphabet;
                }
                else
                {
                    currNum += (double)ch2PositionInAlphabet;
                }

                allNumsFromInput[i] = currNum;
            }

            double sumAllNums = 0.0;
            foreach (var num in allNumsFromInput)
            {
                sumAllNums += num;
            }

            Console.WriteLine($"{sumAllNums:f2}");
        }
    }
}
