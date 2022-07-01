using System;
using System.Collections.Generic;

namespace Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> allStudents = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] splitInput = input.Split(' ');

                Student student = new Student(splitInput[0], splitInput[1], int.Parse(splitInput[2]), splitInput[3]);

                if (IsStudentOnTheList(allStudents, splitInput[0], splitInput[1]))
                {
                    student = allStudents.Find(student => student.FirstName == splitInput[0] && student.LastName == splitInput[1]);
                    student.Age = int.Parse(splitInput[2]);
                    student.Hometown = splitInput[3];
                }
                else
                {
                    allStudents.Add(student);
                }
            }

            string cityName = Console.ReadLine();

            foreach (var student in allStudents)
            {
                if (student.Hometown == cityName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static bool IsStudentOnTheList(List<Student> allStudents, string firstName, string lastName)
        {
            foreach (var student in allStudents)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Hometown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

    }
}
