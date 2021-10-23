using System;

namespace _04.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (product)
            {
                case "coffee":
                    switch (town)
                    {
                        case "Sofia":
                            price = 0.5 * quantity;
                            break;
                        case "Plovdiv":
                            price = 0.4 * quantity;
                            break;
                        case "Varna":
                            price = 0.45 * quantity;
                            break;
                        default:
                            break;
                    }
                    break;
                case "water":
                    switch (town)
                    {
                        case "Sofia":
                            price = 0.8 * quantity;
                            break;
                        case "Plovdiv":
                            price = 0.7 * quantity;
                            break;
                        case "Varna":
                            price = 0.70 * quantity;
                            break;
                        default:
                            break;
                    }
                    break;
                case "beer":
                    switch (town)
                    {
                        case "Sofia":
                            price = 1.20 * quantity;
                            break;
                        case "Plovdiv":
                            price = 1.15 * quantity;
                            break;
                        case "Varna":
                            price = 1.10 * quantity;
                            break;
                        default:
                            break;
                    }
                    break;
                case "sweets":
                    switch (town)
                    {
                        case "Sofia":
                            price = 1.45 * quantity;
                            break;
                        case "Plovdiv":
                            price = 1.30 * quantity;
                            break;
                        case "Varna":
                            price = 1.35 * quantity;
                            break;
                        default:
                            break;
                    }
                    break;
                case "peanuts":
                    switch (town)
                    {
                        case "Sofia":
                            price = 1.60 * quantity;
                            break;
                        case "Plovdiv":
                            price = 1.50 * quantity;
                            break;
                        case "Varna":
                            price = 1.55 * quantity;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine(price);
        }
    }
}
