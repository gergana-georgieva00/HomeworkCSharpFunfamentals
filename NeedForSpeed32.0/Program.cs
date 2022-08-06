using System;
using System.Collections.Generic;

namespace NeedForSpeed32._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|');
                Car car = new Car(input[0], int.Parse(input[1]), int.Parse(input[2]));
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splCommand = command.Split(" : ");

                if (command.Contains("Drive"))
                {
                    string carName = splCommand[1];
                    int distance = int.Parse(splCommand[2]);
                    int fuel = int.Parse(splCommand[3]);

                    Car currCar = cars.Find(c => c.Name == carName);
                    if (currCar.Fuel >= fuel)
                    {
                        currCar.Mileage += distance;
                        currCar.Fuel -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (currCar.Mileage >= 100000)
                    {
                        cars.Remove(currCar);
                        Console.WriteLine($"Time to sell the {currCar.Name}!");
                    }
                }
                else if (command.Contains("Refuel"))
                {
                    string carName = splCommand[1];
                    int fuel = int.Parse(splCommand[2]);

                    Car currCar = cars.Find(c => c.Name == carName);
                    if (currCar.Fuel + fuel > 75)
                    {
                        fuel = 75 - currCar.Fuel;
                    }

                    currCar.Fuel += fuel;
                    Console.WriteLine($"{currCar.Name} refueled with {fuel} liters");
                }
                else
                {
                    string carName = splCommand[1];
                    int kilometers = int.Parse(splCommand[2]);

                    Car currCar = cars.Find(c => c.Name == carName);
                    currCar.Mileage -= kilometers;

                    if (currCar.Mileage < 10000)
                    {
                        currCar.Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{currCar.Name} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
