using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();

            string[] inputPeople = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) ;
            string[] inputProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var currProduct in inputProducts)
            {
                string productName = (currProduct.Split('='))[0];
                int productCost = int.Parse((currProduct.Split('='))[1]);

                Product product = new Product()
                {
                    ProductName = productName,
                    Cost = productCost
                };

                products.Add(product);
            }

            foreach (var currPerson in inputPeople)
            {
                string name = currPerson.Split('=')[0];
                int money = int.Parse(currPerson.Split('=')[1]);

                Person person = new Person()
                {
                    PersonName = name,
                    Money = money,
                    Products = new List<Product>()
                };

                people.Add(person);
            }

            // start buying products
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string namePerson = command.Split(' ')[0];
                string productToBuy = command.Split(' ')[1];

                Person currPerson = people.Find(person => person.PersonName == namePerson);
                Product currProduct = products.Find(product => product.ProductName == productToBuy);

                foreach (var person in people)
                {
                    if (person.PersonName == namePerson)
                    {
                        if (person.Money - currProduct.Cost >= 0)
                        {
                            person.Money -= currProduct.Cost;
                            person.Products.Add(currProduct);
                            Console.WriteLine($"{namePerson} bought {productToBuy}");
                        }
                        else
                        {
                            Console.WriteLine($"{namePerson} can't afford {productToBuy}");
                        }
                    }
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.PersonName} - Nothing bought");
                }
                else
                {
                    Console.Write($"{person.PersonName} - ");

                    List<string> names = new List<string>();
                    foreach (var product in person.Products)
                    {
                        names.Add(product.ProductName);
                    }

                    Console.WriteLine(string.Join(", ", names));
                }
            }
        }
    }

    class Person
    {
        public string PersonName { get; set; }
        public int Money { get; set; }
        public List<Product> Products { get; set; }
    }

    class Product
    {
        public string ProductName { get; set; }
        public int Cost { get; set; }
    }
}
