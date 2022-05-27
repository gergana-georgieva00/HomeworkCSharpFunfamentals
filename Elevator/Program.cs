using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = numberOfPeople / capacity;
            int remainderPeople = numberOfPeople - (courses * capacity);

            if (remainderPeople > 0)
            {
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}
