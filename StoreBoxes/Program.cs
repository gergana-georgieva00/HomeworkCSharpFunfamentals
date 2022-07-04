using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split(' ');

                Box box = new Box
                {
                    SerialNumber = input[0],
                    Item = new Item
                    {
                        Name = input[1],
                        Price = decimal.Parse(input[3])
                    },
                    ItemQuantity = int.Parse(input[2])
                };

                boxes.Add(box);
            }

            foreach (Box box in boxes.OrderByDescending(box => box.PriceBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceBox 
        {
            get 
            {
                return this.ItemQuantity * this.Item.Price;
            } 
        }
    }
}
