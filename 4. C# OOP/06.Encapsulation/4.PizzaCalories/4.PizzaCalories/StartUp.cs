using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;
            var pizzaInfo = Console.ReadLine()
                .Split()
                .ToArray();
            try
            {
                var pizzaName = pizzaInfo[1];
                pizza = new Pizza(pizzaName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            var doughInfo = Console.ReadLine()
                .Split()
                .ToArray();
            var doughType = doughInfo[1];
            var bakingTechnique = doughInfo[2];
            var weight = double.Parse(doughInfo[3]);

            try
            {
                Dough dough = new Dough(doughType, bakingTechnique, weight);
                pizza.Dough = dough;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            while (true)
            {
                var toppingInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                if (toppingInfo.Contains("END"))
                {
                    break;
                }
                var toppingType = toppingInfo[1];
                var toppingWeight = double.Parse(toppingInfo[2]);
                try
                {
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var totalCalories = pizza.CalculateCalories();

            Console.WriteLine($"{pizza.PizzaName} - {totalCalories:F2} Calories.");
        }
    }
}
