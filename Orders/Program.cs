using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string name = command.Split()[0];
                double price = double.Parse(command.Split()[1]);
                double quantity = double.Parse(command.Split()[2]);

                Product product = new Product(name, price, quantity);

                if (products.Any(p => p.Name == name))
                {
                    Product currProduct = products.Find(p => p.Name == name);

                    foreach (var item in products)
                    {
                        if (item.Name == name)
                        {
                            item.Price = price;
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    products.Add(product);
                }
            }

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name} -> {(product.Quantity * product.Price):f2}");
            }
        }
    }

    class Product
    {
        public Product(string name, double price, double quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
