using System;

namespace _04.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double expences = 0.0;

            switch (flowers)
            {
                case "Roses":
                    expences = 5 * countFlowers;
                    if (countFlowers > 80)
                    {
                        expences -= 0.1 * expences;
                    }
                    break;
                case "Dahlias":
                    expences = 3.80 * countFlowers;
                    if (countFlowers > 90)
                    {
                        expences -= 0.15 * expences;
                    }
                    break;
                case "Tulips":
                    expences = 2.80 * countFlowers;
                    if (countFlowers > 80)
                    {
                        expences -= 0.15 * expences;
                    }
                    break;
                case "Narcissus":
                    expences = 3 * countFlowers;
                    if (countFlowers < 120)
                    {
                        expences += 0.15 * expences;
                    }
                    break;
                case "Gladiolus":
                    expences = 2.50 * countFlowers;
                    if (countFlowers < 80)
                    {
                        expences += 0.2 * expences;
                    }
                    break;
                default:
                    break;
            }
            if (budget >= expences)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {flowers} and {(budget - expences):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(expences - budget):F2} leva more.");
            }
        }
    }
}
