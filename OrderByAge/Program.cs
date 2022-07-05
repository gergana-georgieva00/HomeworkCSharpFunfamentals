using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] splInput = input.Split(' ');
                string name = splInput[0];
                string id = splInput[1];
                int age = int.Parse(splInput[2]);

                Person person = new Person(name, id, age);
                foreach (var currPerson in people)
                {
                    if (currPerson.Id == person.Id)
                    {
                        currPerson.Name = person.Name;
                        currPerson.Age = person.Age;
                        continue;
                    }
                }

                people.Add(person);
            }

            List<Person> sorted = people.OrderBy(x => x.Age).ToList();

            foreach (var person in sorted)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}
