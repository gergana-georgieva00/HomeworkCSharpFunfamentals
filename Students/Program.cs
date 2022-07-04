using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Students students = new Students();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                Student student = new Student(input[0], input[1], double.Parse(input[2]));
                students.StudentsList.Add(student);
            }

            foreach (var student in students.StudentsList.OrderByDescending(student => student.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }

    class Students
    {
        public Students()
        {
            this.StudentsList = new List<Student>();
        }

        public List<Student> StudentsList { get; set; }
    }
}
