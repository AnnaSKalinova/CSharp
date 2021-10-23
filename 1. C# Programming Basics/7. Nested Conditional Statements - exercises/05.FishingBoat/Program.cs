using System;

namespace _05.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int countFishers = int.Parse(Console.ReadLine());

            double shipRent = 0.0;

            switch (season)
            {
                case "Spring":
                    shipRent = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    shipRent = 4200;
                    break;
                case "Winter":
                    shipRent = 2600;
                    break;
                default:
                    break;
            }
            if (countFishers <= 6)
            {
                shipRent -= shipRent * 0.10;
            }
            else if (countFishers > 7 && countFishers <= 11)
            {
                shipRent -= shipRent * 0.15;
            }
            else if (countFishers > 12)
            {
                shipRent -= shipRent * 0.25;
            }

            if (countFishers % 2 == 0 && season != "Autumn")
            {
                shipRent -= shipRent * 0.05;
            }

            if (budget >= shipRent)
            {
                Console.WriteLine($"Yes! You have {(budget - shipRent):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(shipRent - budget):F2} leva.");
            }
        }
    }
}
