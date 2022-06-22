using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> drumSetCopy = new List<int>(drumSet);

            string command;
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumSetCopy.Count; i++)
                {
                    drumSetCopy[i] -= hitPower;

                    if (drumSetCopy[i] <= 0)
                    {
                        double priceForNewDrum = (double)drumSet[i] * 3d;
                        if (priceForNewDrum <= savings)
                        {
                            savings -= priceForNewDrum;
                            drumSetCopy[i] = drumSet[i];
                        }
                        else
                        {
                            drumSetCopy.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', drumSetCopy));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
