using System;

namespace _7.AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskyPrice = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskyLiters = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskyPrice / 2;
            double winePrice = rakiaPrice - 0.4 * rakiaPrice;
            double beerPrice = rakiaPrice - 0.8 * rakiaPrice;

            double totalMoneyNeeded = whiskyPrice * whiskyLiters + beerPrice * beerLiters + winePrice * wineLiters + rakiaPrice * rakiaLiters;

            Console.WriteLine($"{totalMoneyNeeded:F2}");
        }
    }
}
