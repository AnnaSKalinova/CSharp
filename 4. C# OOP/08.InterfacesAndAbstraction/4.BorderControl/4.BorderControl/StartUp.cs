using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine()
                .Split()
                .ToArray();

            List<IIdentifiable> dataBase = new List<IIdentifiable>();

            while (!command.Contains("End"))
            {
                switch (command.Length)
                {
                    case 3:
                        var name = command[0];
                        var age = int.Parse(command[1]);
                        var id = command[2];

                        Citizen citizen = new Citizen(name, age, id);
                        dataBase.Add(citizen);
                        break;
                    case 2:
                        var model = command[0];
                        id = command[1];

                        Robot robot = new Robot(model, id);
                        dataBase.Add(robot);
                        break;
                }

                command = Console.ReadLine()
                .Split()
                .ToArray();
            }

            var fakeIDsEnd = int.Parse(Console.ReadLine());

            dataBase.Where(x => x.Id.EndsWith(fakeIDsEnd.ToString()))
                .Select(i => i.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
