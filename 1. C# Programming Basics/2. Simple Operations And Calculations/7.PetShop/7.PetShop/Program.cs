using System;

namespace _7.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsCount = int.Parse(Console.ReadLine());
            int otherAnimalsCount = int.Parse(Console.ReadLine());

            double expences = dogsCount * 2.50 + otherAnimalsCount * 4;

            Console.WriteLine($"{expences:F2} lv.");
        }
    }
}
