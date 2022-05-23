using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            // logic
            int trashedHeadSetCount = 0;
            int trashedMouseCount = 0;
            int trashedKeyboardCount = 0;
            int trashedDisplayCount = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashedKeyboardCount++;

                    if (trashedKeyboardCount % 2 == 0)
                    {
                        trashedDisplayCount++;
                    }
                }

                if (i % 2 == 0)
                {
                    trashedHeadSetCount++;
                }

                if (i % 3 == 0)
                {
                    trashedMouseCount++;
                }
            }

            double expenses = (double)trashedHeadSetCount * headsetPrice + (double)trashedMouseCount * mousePrice + (double)trashedKeyboardCount * keyboardPrice + (double)trashedDisplayCount * displayPrice;
            
            // output
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
