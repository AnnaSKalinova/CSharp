using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = "Pesho";
            int age = 24;

            Person person = new Person(name, age);

            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
