using System;

namespace WildFarm
{
    public class CreateAnimals
    {
        public static Animal CreateAnimal(string[] animalInfo)
        {
            var name = animalInfo[1];
            var weight = double.Parse(animalInfo[2]);
            Animal animal = null;

            switch (animalInfo[0])
            {
                case "Cat":
                    var livingRegion = animalInfo[3];
                    var breed = animalInfo[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;
                case "Tiger":
                    livingRegion = animalInfo[3];
                    breed = animalInfo[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;
                case "Owl":
                    var wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wingSize);
                    break;
                case "Hen":
                    wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                    break;
                case "Mouse":
                    livingRegion = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegion);
                    break;
                case "Dog":
                    livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;
                default:
                    throw new ArgumentException("Invalid animal");
            }

            return animal;
        }
    }
}
