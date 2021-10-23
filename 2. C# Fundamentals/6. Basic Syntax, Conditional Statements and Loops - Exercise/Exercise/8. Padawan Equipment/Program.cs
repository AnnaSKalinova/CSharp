using System;

namespace _8._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalPriceLightsabers = Math.Ceiling(studentsCount + 0.10 * studentsCount) * priceOfLightsabers;
            double totalpriceRobes = studentsCount * priceOfRobes;

            if (studentsCount > 6)
            {
                studentsCount -= studentsCount / 6;
            }
            double totalPriceBelts = studentsCount * priceOfBelts;

            double totalPrice = totalPriceLightsabers + totalpriceRobes + totalPriceBelts;

            if (amountOfMoney >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - amountOfMoney):F2}lv more.");
            }
        }
    }
}
