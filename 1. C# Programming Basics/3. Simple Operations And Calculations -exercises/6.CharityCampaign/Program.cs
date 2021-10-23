using System;

namespace _6.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int bakersCount = int.Parse(Console.ReadLine());
            int cakesPerDay = int.Parse(Console.ReadLine());
            int wafflesPerDay = int.Parse(Console.ReadLine());
            int pancakesPerDay = int.Parse(Console.ReadLine());
            
            double cakesPrice = 45;
            double wafflesPrice = 5.80;
            double pancakesPrice = 3.20;

            double productionPerDay = cakesPrice * cakesPerDay + wafflesPrice * wafflesPerDay + pancakesPrice * pancakesPerDay;

            double productionPerBaker = productionPerDay * daysCount;
            double totalProduction = productionPerBaker * bakersCount;
            double total = totalProduction - totalProduction / 8;

            Console.WriteLine($"{total:F2}");
        }
    }
}
