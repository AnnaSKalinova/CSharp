using System;

namespace _08.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int teddyBearCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double order = puzzlesCount * 2.60 + dollsCount * 3 + teddyBearCount * 4.10 + minionsCount * 8.20 + trucksCount * 2;

            if (puzzlesCount + dollsCount + teddyBearCount + minionsCount + trucksCount >= 50)
            {
                order -= 25 * order / 100;
            }

            double rent = order * 10 / 100;
            double profit = order - rent;

            if (profit >= excursionPrice)
            {

                Console.WriteLine($"Yes! {(profit - excursionPrice):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(excursionPrice - profit):F2} lv needed.");
            }
        }
    }
}
