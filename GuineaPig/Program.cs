using System;

namespace GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            int days = 1;
            bool fineOrNot = true;
            while (days <= 30)
            {
                food -= 300;

                if (days % 2 == 0)
                {
                    double amountOfHay = 0.05 * food;
                    hay -= amountOfHay;
                }

                if (days % 3 == 0)
                {
                    double quantity = weight / 3d;
                    cover -= quantity;
                }

                days++;

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    fineOrNot = false;
                    break;
                }
            }

            if (fineOrNot)
            {
                food /= 1000d;
                hay /= 1000d;
                cover /= 1000d;
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}
