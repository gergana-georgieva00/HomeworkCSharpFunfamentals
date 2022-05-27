using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long m = long.Parse(Console.ReadLine());
            long y = long.Parse(Console.ReadLine());

            double nPercent = (double)n / 2d;
            long targetsPoked = 0;
            
            while (n >= m)
            {
                n -= m;
                targetsPoked++;

                if (n < m)
                {
                    break;
                }

                if (n == nPercent && y != 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(targetsPoked);
        }
    }
}
