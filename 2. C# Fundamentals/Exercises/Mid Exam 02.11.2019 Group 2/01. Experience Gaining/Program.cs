using System;

namespace _01._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfExperienceNeeded = decimal.Parse(Console.ReadLine());
            int totalBattlesCount = int.Parse(Console.ReadLine());

            int counterOfBattles = 0;
            decimal experienceGained = 0;

            for (int i = 0; i < totalBattlesCount; i++)
            {
                counterOfBattles++;
                decimal currentExperience = decimal.Parse(Console.ReadLine());
                
                if (counterOfBattles % 3 == 0)
                {
                    currentExperience += 0.15M * currentExperience;
                }
                else if (counterOfBattles % 5 == 0)
                {
                    currentExperience -= 0.1M * currentExperience;
                }

                experienceGained += currentExperience;

                if (experienceGained >= amountOfExperienceNeeded)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {counterOfBattles} battles.");
                    return;
                }
            }

            Console.WriteLine($"Player was not able to collect the needed experience, {(amountOfExperienceNeeded - experienceGained):F2} more needed.");
        }
    }
}
