using System;

namespace FoodShortage
{
    public class Citizen : INameable, IIdentifieble, IBirthdatable, IAgeble, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/MM/yyyy", null);
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public DateTime Birthdate { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            return this.Food = 10;
        }
    }
}
