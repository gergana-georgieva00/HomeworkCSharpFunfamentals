using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currCar = Console.ReadLine().Split('|');
                Car car = new Car(currCar[0], int.Parse(currCar[1]), int.Parse(currCar[2]));
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] comSplit = command.Split(" : ");

                if (command.Contains("Drive"))
                {
                    string carName = comSplit[1];
                    int distance = int.Parse(comSplit[2]);
                    int fuel = int.Parse(comSplit[3]);

                    Car carCurr = cars.Find(c => c.Name == carName);
                    
                    if (carCurr.Fuel >= fuel)
                    {
                        
                        carCurr.Fuel -= fuel;
                        carCurr.Mileage += distance;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (carCurr.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {carName}!");
                            Car currCar = cars.Find(x => x.Name == carName);
                            cars.Remove(currCar);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    
                }
                else if (command.Contains("Refuel"))
                {
                    string car = comSplit[1];
                    int fuel = int.Parse(comSplit[2]);

                    Car carCurr = cars.Find(c => c.Name == car);

                    if (carCurr.Fuel + fuel > 75)
                    {
                        fuel = 75 - carCurr.Fuel;
                        carCurr.Fuel = 75;
                    }
                    else
                    {
                        carCurr.Fuel += fuel;
                    }
                    
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else
                {
                    string car = comSplit[1];
                    int kilometers = int.Parse(comSplit[2]);

                    Car carCurr = cars.Find(c => c.Name == car);
                    carCurr.Mileage -= kilometers;

                    if (carCurr.Mileage < 10000)
                    {
                        carCurr.Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (Car car in cars)
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
