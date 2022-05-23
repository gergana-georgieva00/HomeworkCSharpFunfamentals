using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double total = 0.0;
            for (int i = 0; i < n; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double capsuleCount = double.Parse(Console.ReadLine());

                double currPriceCoffee = pricePerCapsule * (double)days * capsuleCount;
                Console.WriteLine($"The price for the coffee is: ${currPriceCoffee:f2}");
                total += currPriceCoffee;
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
