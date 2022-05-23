using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            double collectedMoney = 0.0;
            while ((command = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(command);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1.0 || coins == 2.0)
                {
                    collectedMoney += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    continue;
                }
            }

            double priceProduct = 0.0;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Nuts" || command == "Water" || command == "Crisps" || command == "Soda" || command == "Coke") 
                {
                    switch (command)
                    {
                        case "Nuts":
                            priceProduct = 2.0;
                            break;
                        case "Water":
                            priceProduct = 0.7;
                            break;
                        case "Crisps":
                            priceProduct = 1.5;
                            break;
                        case "Soda":
                            priceProduct = 0.8;
                            break;
                        case "Coke":
                            priceProduct = 1.0;
                            break;
                    }

                    if (priceProduct <= collectedMoney)
                    {
                        Console.WriteLine($"Purchased {command.ToLower()}");
                        collectedMoney -= priceProduct;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }
            }

            Console.WriteLine($"Change: {collectedMoney:f2}");
        }
    }
}
