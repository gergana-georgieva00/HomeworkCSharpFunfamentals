using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] splitCom = command.Split('/');

                if (splitCom[0] == "Car")
                {
                    Car car = new Car
                    {
                        Brand = splitCom[1],
                        Model = splitCom[2],
                        HorsePower = double.Parse(splitCom[3])
                    };

                    catalog.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck
                    {
                        Brand = splitCom[1],
                        Model = splitCom[2],
                        Weight = double.Parse(splitCom[3])
                    };

                    catalog.Trucks.Add(truck);
                }
            }

            Console.WriteLine("Cars:");
            foreach (var car in catalog.Cars.OrderBy(car => car.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (var truck in catalog.Trucks.OrderBy(truck => truck.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    class Catalog
    {
        public Catalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
