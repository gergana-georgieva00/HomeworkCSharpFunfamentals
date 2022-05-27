using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            BigInteger snowballValue;
            BigInteger highestValue = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;
            
            for (int i = 0; i < N; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                if (snowballValue > highestValue)
                {
                    highestValue = snowballValue;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                 }
            }

            Console.WriteLine($"{snow} : {time} = {highestValue} ({quality})");
            
            
        }
    }
}
