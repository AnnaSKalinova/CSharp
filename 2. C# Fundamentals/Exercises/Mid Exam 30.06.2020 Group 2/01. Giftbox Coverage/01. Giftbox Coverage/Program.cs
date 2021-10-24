using System;

namespace _01._Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int sheetsOfPaper = int.Parse(Console.ReadLine());
            double areaCoveredBy1Sheet = double.Parse(Console.ReadLine());

            double giftBoxArea = sideSize * sideSize * 6;
            double areaCovered = 0.0;

            for (int i = 1; i <= sheetsOfPaper; i++)
            {
                if (i % 3 == 0)
                {
                    areaCovered += areaCoveredBy1Sheet * 0.25;
                }
                else
                {
                    areaCovered += areaCoveredBy1Sheet;
                }
            }

            double percentageCovered = areaCovered / giftBoxArea * 100;
            Console.WriteLine($"You can cover {percentageCovered:F2}% of the box.");
        }
    }
}
