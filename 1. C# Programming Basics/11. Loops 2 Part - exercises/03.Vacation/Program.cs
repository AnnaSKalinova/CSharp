using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForExcursion = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());

            int daysCounter = 0;
            int spendingCounter = 0;
            bool isMoneySaved = false;

            while (ownedMoney < moneyForExcursion)
            {
                string moneyAction = Console.ReadLine();
                double dailyMoney = double.Parse(Console.ReadLine());
                daysCounter++;

                if (moneyAction == "spend")
                {
                    ownedMoney -= dailyMoney;

                    if (ownedMoney < 0)
                    {
                        ownedMoney = 0;
                    }
                    spendingCounter++;

                    if (spendingCounter == 5)
                    {
                        break;
                    }
                }
                else if (moneyAction == "save")
                {
                    ownedMoney += dailyMoney;
                    spendingCounter = 0;
                }

                if (ownedMoney >= moneyForExcursion)
                {
                    isMoneySaved = true;
                    break;
                }
            }

            if (isMoneySaved)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
        }
    }
}
