using System;

namespace _4.TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tablesCount = int.Parse(Console.ReadLine());
            double tableLenght = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());

            double pokrivkaLenght = tableLenght + 0.60;
            double pokrivkaWidth = tableWidth + 0.60;
            double pokrivkaArea = pokrivkaLenght * pokrivkaWidth;
            double kareArea = tableLenght / 2 * tableLenght / 2;

            double priceForPokrivka = pokrivkaArea * tablesCount * 7;
            double priceForKare = kareArea * tablesCount * 9;

            double totalPriceUSD = priceForKare + priceForPokrivka;
            double totalPriceBGN = totalPriceUSD * 1.85;

            Console.WriteLine($"{totalPriceUSD:F2} USD");
            Console.WriteLine($"{totalPriceBGN:F2} BGN");
        }
    }
}
