using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceOfMachine = double.Parse(Console.ReadLine());
            int toyCost = int.Parse(Console.ReadLine());
            double savedMoney = 0;
            int toysCount = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += 10 * i / 2;
                    savedMoney -= 1;
                }
                else
                {
                    toysCount++;
                }
            }
            savedMoney += toysCount * toyCost;

            if (savedMoney >= priceOfMachine)
            {
                Console.WriteLine($"Yes! {(savedMoney - priceOfMachine):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(priceOfMachine - savedMoney):F2}");
            }
        }
    }
}
