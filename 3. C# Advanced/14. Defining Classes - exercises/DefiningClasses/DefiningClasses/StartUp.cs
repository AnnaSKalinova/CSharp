using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            
            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> olderThan30 = family.OlderThat30();

            foreach (var person in olderThan30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
