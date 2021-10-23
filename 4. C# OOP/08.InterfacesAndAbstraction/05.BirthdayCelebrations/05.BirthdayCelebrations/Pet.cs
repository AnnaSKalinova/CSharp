using System;

namespace BirthdayCelebrations
{
    public class Pet : INameable, IBirthdatable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/MM/yyyy", null);
        }
        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
