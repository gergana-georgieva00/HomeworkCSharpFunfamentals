using System;
using System.Collections.Generic;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int rotations = int.Parse(Console.ReadLine());

            string[] inputArrString = input.Split(' ');
            List<string> currList = new List<string>(inputArrString);

            for (int i = 0; i < rotations; i++)
            {
                string elementMoving = currList[0];
                currList.RemoveAt(0);
                currList.Add(elementMoving);
            }

            foreach (var item in currList)
            {
                Console.Write(item + " ");
            }
        }
    }
}
