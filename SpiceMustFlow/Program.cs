using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int days = 0;
            int spiceExtracted = number;
            int spiceSum = 0;

            if (number < 100)
            {
                Console.WriteLine(days);
                Console.WriteLine(spiceSum);
            }
            else
            {
                while (true)
                {
                    if (number < 100)
                    {
                        spiceSum -= 26;
                        break;
                    }

                    number -= 10;
                    spiceExtracted -= 26;
                    spiceSum += spiceExtracted;
                    days++;
                    spiceExtracted = number;
                }

                Console.WriteLine(days);
                Console.WriteLine(spiceSum);
            }
        }
    }
}
