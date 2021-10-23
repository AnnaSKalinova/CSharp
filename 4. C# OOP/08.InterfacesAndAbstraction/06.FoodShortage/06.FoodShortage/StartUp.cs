using FoodShortage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numOfPeople = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numOfPeople; i++)
            {
                var person = Console.ReadLine()
                    .Split()
                    .ToArray();
                switch (person.Length)
                {
                    case 4:
                        var name = person[0];
                        var age = int.Parse(person[1]);
                        var id = person[2];
                        var birthdate = person[3];
                        Citizen citizen = new Citizen(name, age, id, birthdate);
                        buyers.Add(citizen);
                        break;
                    case 3:
                        name = person[0];
                        age = int.Parse(person[1]);
                        var group = person[2];
                        Rebel rebel = new Rebel(name, age, group);
                        buyers.Add(rebel);
                        break;
                }
            }

            var purchasedFood = 0;
            var buyer = Console.ReadLine();

            while (buyer != "End")
            {
                if (buyers.Any(b => b.Name == buyer))
                {
                    var currentBuyer = buyers.Where(b => b.Name == buyer).First();
                    purchasedFood += currentBuyer.BuyFood();
                }

                buyer = Console.ReadLine();
            }

            Console.WriteLine(purchasedFood);
        }
    }
}
