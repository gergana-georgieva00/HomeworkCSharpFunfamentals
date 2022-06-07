using System;
using System.Collections.Generic;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(' ');
            string[] secondArray = Console.ReadLine().Split(' ');

            List<string> commonElements = new List<string>();

            for (int i = 0; i < secondArray.Length; i++)
            {
                string currElementOne = secondArray[i];
                for (int j = 0; j < firstArray.Length; j++)
                {
                    string currElementTwo = firstArray[j];
                    if (currElementOne == currElementTwo)
                    {
                        commonElements.Add(currElementOne);
                    }
                }
            }

            foreach (var item in commonElements)
            {
                Console.Write(item + " ");
            }
        }
    }
}
