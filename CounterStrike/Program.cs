using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            long initialEnergy = long.Parse(Console.ReadLine());

            bool notEhoughEnergy = false;
            long wonBattles = 0;
            string command;

            while ((command = Console.ReadLine()) != "End of battle")
            {
                long distance = long.Parse(command);

                if (initialEnergy - distance < 0)
                {
                    notEhoughEnergy = true;
                    break;
                }

                initialEnergy -= distance;

                wonBattles++;

                if (wonBattles % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }
            }

            if (notEhoughEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
            }
        }
    }
}
