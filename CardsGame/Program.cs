using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> winner = new List<int>();

            while (firstHand.Count > 0 && secondHand.Count > 0)
            {
                if (firstHand[0] == secondHand[0])
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else
                {
                    if (firstHand[0] > secondHand[0])
                    {
                        int movingElementSecond = secondHand[0];
                        secondHand.RemoveAt(0);
                        int movingElementFirst = firstHand[0];
                        firstHand.RemoveAt(0);
                        firstHand.Add(movingElementFirst);
                        firstHand.Add(movingElementSecond);
                    }
                    else
                    {
                        int movingElementFirst = firstHand[0];
                        firstHand.RemoveAt(0);
                        int movingElementSecond = secondHand[0];
                        secondHand.RemoveAt(0);
                        secondHand.Add(movingElementSecond);
                        secondHand.Add(movingElementFirst);
                    }
                }
            }

            string firstOrSecond = string.Empty;
            if (firstHand.Count == 0)
            {
                winner = secondHand;
                firstOrSecond = "Second";
            }
            else
            {
                winner = firstHand;
                firstOrSecond = "First";
            }

            int sum = 0;
            foreach (var num in winner)
            {
                sum += num;
            }

            Console.WriteLine($"{firstOrSecond} player wins! Sum: {sum}");
        }
    }
}
