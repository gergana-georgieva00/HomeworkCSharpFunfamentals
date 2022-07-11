using System;
using System.Collections.Generic;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string course = command.Split(" : ")[0];
                string studentName = command.Split(" : ")[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                
                courses[course].Add(studentName);
            }

            foreach (var pair in courses)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count}");

                foreach (var student in pair.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
