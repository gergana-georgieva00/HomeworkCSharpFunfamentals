using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double pricePerPerson = 0.00d;
            double discount = 0.00d;

            if (typeOfGroup == "Students")
            {
                if (countOfPeople >= 30)
                {
                    discount = 0.15;
                }

                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerPerson = 8.45;
                        break;
                    case "Saturday":
                        pricePerPerson = 9.80;
                        break;
                    case "Sunday":
                        pricePerPerson = 10.46;
                        break;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (countOfPeople >= 100)
                {
                    countOfPeople -= 10;
                }

                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerPerson = 10.90;
                        break;
                    case "Saturday":
                        pricePerPerson = 15.60;
                        break;
                    case "Sunday":
                        pricePerPerson = 16.00;
                        break;
                }
            }
            else
            {
                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    discount = 0.05;
                }
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerPerson = 15;
                        break;
                    case "Saturday":
                        pricePerPerson = 20;
                        break;
                    case "Sunday":
                        pricePerPerson = 22.50;
                        break;
                }
            }

            double priceTotal = pricePerPerson * (double)countOfPeople;
            priceTotal -= priceTotal * discount;

            Console.WriteLine($"Total price: {priceTotal:f2}");
        }
    }
}
