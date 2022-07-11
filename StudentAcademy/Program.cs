using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsAndGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsAndGrades.ContainsKey(name))
                {
                    studentsAndGrades.Add(name, new List<double>());
                }
                
                studentsAndGrades[name].Add(grade);
            }

            foreach (var pair in studentsAndGrades)
            {
                if (pair.Value.AsQueryable().Sum() / pair.Value.Count < 4.5)
                {
                    studentsAndGrades.Remove(pair.Key);
                }
            }

            foreach (var pair in studentsAndGrades)
            {
                Console.WriteLine($"{pair.Key} -> {(pair.Value.AsQueryable().Sum() / pair.Value.Count):f2}");
            }
        }
    }
}
