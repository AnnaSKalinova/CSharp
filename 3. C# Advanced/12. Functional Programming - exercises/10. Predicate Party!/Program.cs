using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfPeopleComing = Console.ReadLine()
                .Split()
                .ToList();
            var command = Console.ReadLine()
                .Split()
                .ToArray();

            while (!command.Contains("Party!"))
            {
                var givenString = command[2];
                Predicate<string> nameStartFilter = x => x.StartsWith(givenString);
                Predicate<string> nameEndsFilter = x => x.EndsWith(givenString);
                Predicate<string> lengthFilter = x => x.Length == int.Parse(givenString);

                if (command[1] == "StartsWith")
                {
                    listOfPeopleComing = ListOfPeopleComing(listOfPeopleComing, command[0], nameStartFilter);
                }
                if (command[1] == "EndsWith")
                {
                    listOfPeopleComing = ListOfPeopleComing(listOfPeopleComing, command[0], nameEndsFilter);
                }
                if (command[1] == "Length")
                {
                    listOfPeopleComing = ListOfPeopleComing(listOfPeopleComing, command[0], lengthFilter);
                }

                command = Console.ReadLine()
                .Split()
                .ToArray();
            }

            if (listOfPeopleComing.Any())
            {
                Console.WriteLine($"{string.Join(", ", listOfPeopleComing)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        static List<string> ListOfPeopleComing(List<string> peopleComing, string command, Predicate<string> predicate)
        {
            for (int i = peopleComing.Count - 1; i >= 0; i--)
            {
                if (predicate(peopleComing[i]))
                {
                    if (command.Equals("Remove"))
                    {
                        peopleComing.Remove(peopleComing[i]);
                    }
                    else if (command.Equals("Double"))
                    {
                        peopleComing.Add(peopleComing[i]);
                    }
                }
            }
            return peopleComing;
        }
    }
}
