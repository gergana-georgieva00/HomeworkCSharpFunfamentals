using System;

namespace ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());

            double experienceTotal = 0.0;
            int counter = 0;
            while (experienceTotal < neededExperience && counter < countOfBattles)
            {
                counter++;
                double experienceEarnedPerBattle = double.Parse(Console.ReadLine());

                if (counter % 3 == 0)
                {
                    experienceEarnedPerBattle += experienceEarnedPerBattle * 0.15;
                }

                if (counter % 5 == 0)
                {
                    experienceEarnedPerBattle -= experienceEarnedPerBattle * 0.1;
                }

                if (counter % 15 == 0)
                {
                    experienceEarnedPerBattle += experienceEarnedPerBattle * 0.05;
                }

                experienceTotal += experienceEarnedPerBattle;
            }

            if (experienceTotal < neededExperience)
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(neededExperience - experienceTotal):f2} more needed.");
            }
            else
            {
                Console.WriteLine($"Player successfully collected his needed experience for {counter} battles.");
            }
        }
    }
}
