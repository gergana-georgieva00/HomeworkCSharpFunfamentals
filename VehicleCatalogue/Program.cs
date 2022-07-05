using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ');
                string typeOfVehicle = input[0];
                string model = input[1];
                string color = input[2];
                int horsepower = int.Parse(input[3]);

                if (typeOfVehicle == "car")
                {
                    Car car = new Car()
                    {
                        Model = model,
                        Color = color,
                        Horsepower = horsepower
                    };

                    cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck()
                    {
                        Model = model,
                        Color = color,
                        Horsepower = horsepower
                    };

                    trucks.Add(truck);
                }
            }

            List<string> vehicles = new List<string>();
            string info;
            while ((info = Console.ReadLine()) != "Close the Catalogue")
            {
                vehicles.Add(info);
            }

            int horsePowerCars = 0;
            foreach (var car in cars)
            {
                horsePowerCars += car.Horsepower;
            }

            int horsePowerTrucks = 0;
            foreach (var truck in trucks)
            {
                horsePowerTrucks += truck.Horsepower;
            }


            foreach (var vehicle in vehicles)
            {
                foreach (var car in cars)
                {
                    if (car.Model == vehicle)
                    {
                        Console.WriteLine("Type: Car");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.Horsepower}");
                    }
                }

                foreach (var truck in trucks)
                {
                    if (truck.Model == vehicle)
                    {
                        Console.WriteLine("Type: Truck");
                        Console.WriteLine($"Model: {truck.Model}");
                        Console.WriteLine($"Color: {truck.Color}");
                        Console.WriteLine($"Horsepower: {truck.Horsepower}");
                    }
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(double)((double)horsePowerCars / (double)cars.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(double)((double)horsePowerTrucks / (double)trucks.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
            
        }
    }

    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
