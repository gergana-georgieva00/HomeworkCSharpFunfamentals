using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                double fuelAmount = int.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumption,
                    TraveledDistance = 0
                };

                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ');
                string model = input[1];
                double distance = double.Parse(input[2]);

                Car currentCar = cars.Find(car => car.Model == model);

                if (currentCar.CanCarMoveTheDistance(currentCar.FuelConsumptionPerKilometer, distance, currentCar.FuelAmount))
                {
                    foreach (var car in cars)
                    {
                        if (car.Model == model)
                        {
                            car.FuelAmount -= distance * car.FuelConsumptionPerKilometer;
                            car.TraveledDistance += distance;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }


        public bool CanCarMoveTheDistance(double fuelConsumption, double distance, double fuelAmount)
        {
            double usedFuel = distance * fuelConsumption;

            if (fuelAmount - usedFuel >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
