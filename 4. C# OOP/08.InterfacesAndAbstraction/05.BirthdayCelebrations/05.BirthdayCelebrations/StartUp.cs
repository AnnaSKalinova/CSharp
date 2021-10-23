using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine()
                .Split()
                .ToArray();
            List<IBirthdatable> dataBase = new List<IBirthdatable>();

            while (!command.Contains("End"))
            {
                switch (command[0])
                {
                    case "Citizen":
                        var name = command[1];
                        var age = int.Parse(command[2]);
                        var id = command[3];
                        var birthDate = command[4];

                        Citizen citizen = new Citizen(name, age, id, birthDate);
                        dataBase.Add(citizen);
                        break;
                    case "Robot":
                        var model = command[1];
                        id = command[2];

                        Robot robot = new Robot(model, id);
                        break;
                    case "Pet":
                        name = command[1];
                        birthDate = command[2];

                        Pet pet = new Pet(name, birthDate);
                        dataBase.Add(pet);
                        break;
                }

                command = Console.ReadLine()
                .Split()
                .ToArray();
            }

            var yearToCheck = int.Parse(Console.ReadLine());

            dataBase.Where(x => x.Birthdate.Year == yearToCheck)
                .Select(y => y.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine(@$"{dt:dd\/MM\/yyyy}"));
        }
    }
}
