using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            List<string> departments = new List<string>();
            foreach (var employee in employees)
            {
                if (!departments.Contains(employee.Department))
                {
                    departments.Add(employee.Department);
                }
            }

            departments.Sort();
            List<string> noDupes = departments.Distinct().ToList();

            double currAverage = 0;
            int currCount = 0;
            double bestAverage = 0;
            string bestDepartment = string.Empty;
            foreach (var department in noDupes)
            {
                foreach (var employee in employees)
                {
                    if (employee.Department == department)
                    {
                        currAverage += employee.Salary;
                        currCount++;
                    }
                }

                currAverage /= currCount;
                if (currAverage > bestAverage)
                {
                    bestAverage = currAverage;
                    bestDepartment = department;
                }

                currCount = 0;
                currAverage = 0;
            }

            List<Employee> emplFromBestDep = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.Department == bestDepartment)
                {
                    emplFromBestDep.Add(employee);
                }
            }

            List<Employee> emplSorted = emplFromBestDep.OrderByDescending(x => x.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            foreach (var employee in emplSorted)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
