using System;

namespace _10.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();

            double price = 0;
            double discount = 0;

            switch (roomType)
            {
                case "room for one person":
                    price = (days - 1) * 18;
                    break;
                case "apartment":
                    if (days < 10)
                    {
                        discount = 0.30;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.35;
                    }
                    else if (days > 15)
                    {
                        discount = 0.5;
                    }
                    price = (days - 1) * 25;
                    price -= price * discount;
                    break;
                case "president apartment":
                    if (days < 10)
                    {
                        discount = 0.10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.15;
                    }
                    else if (days > 15)
                    {
                        discount = 0.20;
                    }
                    price = (days - 1) * 35;
                    price -= price * discount;
                    break;
                default:
                    break;
            }

            if (feedback == "positive")
            {
                price += price * 0.25;
            }
            else if (feedback == "negative")
            {
                price -= price * 0.10;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
