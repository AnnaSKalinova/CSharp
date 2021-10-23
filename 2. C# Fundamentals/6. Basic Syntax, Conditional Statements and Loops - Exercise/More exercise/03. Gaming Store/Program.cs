using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            double gamePrice = 0.0;
            double totalSpent = 0.0;
            bool isOutOfMoney = false;

            while (command != "Game Time")
            {
                switch (command)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        command = Console.ReadLine();
                        continue;
                }

                if (balance >= gamePrice)
                {
                    totalSpent += gamePrice;
                    balance -= gamePrice;
                    Console.WriteLine($"Bought {command}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                if (balance <= 0)
                {
                    Console.WriteLine("Out of money! ");
                    isOutOfMoney = true;
                    break;
                }
                command = Console.ReadLine();
                gamePrice = 0.0;
            }

            if (!isOutOfMoney)
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
