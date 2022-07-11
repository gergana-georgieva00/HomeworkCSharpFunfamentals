using System;
using System.Collections.Generic;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployee = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string company = input.Split(" -> ")[0];
                string id = input.Split(" -> ")[1];

                if (!companyEmployee.ContainsKey(company))
                {
                    companyEmployee.Add(company, new List<string>());
                    companyEmployee[company].Add(id);
                }
                else
                {
                    if (!companyEmployee[company].Contains(id))
                    {
                        companyEmployee[company].Add(id);
                    }
                }
            }

            foreach (var pair in companyEmployee)
            {
                Console.WriteLine($"{pair.Key}");

                foreach (var id in pair.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
