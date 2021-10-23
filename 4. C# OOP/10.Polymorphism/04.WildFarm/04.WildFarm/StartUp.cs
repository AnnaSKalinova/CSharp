using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                var animalInfo = Console.ReadLine()
                .Split()
                .ToArray();

                if (animalInfo.Contains("End"))
                {
                    break;
                }

                Animal animal = CreateAnimals.CreateAnimal(animalInfo);
                Console.WriteLine(animal.ProduceASound()); 

                var foodInfo = Console.ReadLine()
                .Split()
                .ToArray();
                var foodType = foodInfo[0];
                var foodQuantity = int.Parse(foodInfo[1]);
                Food food = CreateFood(foodType, foodQuantity);

                try
                {
                    animal.EatFood(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string foodType, int foodQuantity)
        {
            Food food = null;

            switch (foodType)
            {
                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;
                case "Meat":
                    food = new Meat(foodQuantity);
                    break;
                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;
                default:
                    break;
            }

            return food;
        }
    }
}
