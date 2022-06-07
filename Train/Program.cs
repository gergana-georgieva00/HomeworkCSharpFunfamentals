using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] people = new int[n];
            int totalPassengers = 0;

            for (int i = 0; i < n; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                Console.Write(people[i] + " ");
                totalPassengers += people[i];
            }

            Console.WriteLine();
            Console.WriteLine(totalPassengers);
        }
    }
}
