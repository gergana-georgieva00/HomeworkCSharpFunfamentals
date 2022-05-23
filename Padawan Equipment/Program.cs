using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            decimal amountOfMoneyJohnHas = decimal.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            decimal pricePerLightsaber = decimal.Parse(Console.ReadLine());
            decimal pricePerRobe = decimal.Parse(Console.ReadLine());
            decimal pricePerBelt = decimal.Parse(Console.ReadLine());

            // logic
            decimal numOfLightSabers = Math.Ceiling((decimal) studentCount + (decimal)studentCount * 0.1m);
            decimal numOfFreeBelts = Math.Floor((decimal)studentCount / 6.0m);

            decimal priceLightSabers = numOfLightSabers * pricePerLightsaber;
            decimal priceRobes = (decimal)studentCount * pricePerRobe;
            decimal priceBelts = ((decimal)studentCount - numOfFreeBelts) * pricePerBelt;

            decimal priceNeededEquipment = priceLightSabers + priceRobes + priceBelts;

            // output
            if (priceNeededEquipment <= amountOfMoneyJohnHas)
            {
                Console.WriteLine($"The money is enough - it would cost {priceNeededEquipment:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(priceNeededEquipment - amountOfMoneyJohnHas):f2}lv more.");
            }
        }
    }
}
