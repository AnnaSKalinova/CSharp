using System;

namespace _06.GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            double costumePricePerPerson = double.Parse(Console.ReadLine());

            double costumePriceTotal = costumePricePerPerson * peopleCount;
            double decor = budget * 0.1;
            if (peopleCount > 150)
            {
                costumePriceTotal -= costumePriceTotal * 0.1;
            }
            if (costumePriceTotal + decor <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - costumePriceTotal - decor):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {((decor + costumePriceTotal) - budget):F2} leva more.");
            }
        }
    }
}
