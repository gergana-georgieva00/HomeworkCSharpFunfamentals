using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 255;
            int litersFilled = 0;
            for (int i = 0; i < n; i++)
            {
                int quantity = int.Parse(Console.ReadLine());
                if (quantity + litersFilled <= capacity)
                {
                    litersFilled += quantity;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(litersFilled);
        }
    }
}
