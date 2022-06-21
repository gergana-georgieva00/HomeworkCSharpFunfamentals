using System;
using System.Collections.Generic;
using System.Text;

namespace TakeOrSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbersList = new List<int>();
            List<char> nonNumbersList = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    numbersList.Add(int.Parse(input[i].ToString()));
                }
                else
                {
                    nonNumbersList.Add(input[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }

            List<char> result = new List<char>();
            for (int i = 0; i < takeList.Count; i++)
            {
                int take = takeList[i];
                int skip = skipList[i];

                for (int j = 0; j < take; j++)
                {
                    if (j >= nonNumbersList.Count)
                    {
                        take = nonNumbersList.Count;
                        break;
                    }

                    result.Add(nonNumbersList[j]);
                }

                

                nonNumbersList.RemoveRange(0, take);

                if (skip >= nonNumbersList.Count)
                {
                    skip = nonNumbersList.Count;
                }

                nonNumbersList.RemoveRange(0, skip);
            }

            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}
