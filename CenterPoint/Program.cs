using System;

namespace CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            FindTheClosestCoordinates(x1, y1, x2, y2);
        }

        static void FindTheClosestCoordinates(double x1, double y1, double x2, double y2)
        {
            double c1 = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double c2 = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (c1 < c2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
