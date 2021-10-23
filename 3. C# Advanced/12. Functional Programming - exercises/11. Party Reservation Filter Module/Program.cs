using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace _11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var invitations = Console.ReadLine()
                .Split()
                .ToList();
            var command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var filteredInvitations = new List<string>(invitations);

            while (!command.Contains("Print"))
            {
                var filterType = command[1];
                var filterParameter = command[2];
                
                Predicate<string> startsWithFlter = x => x.StartsWith(filterParameter);
                Predicate<string> endsWithFilter = x => x.EndsWith(filterParameter);
                Predicate<string> lengthFilter = x => x.Length == int.Parse(filterParameter);
                Predicate<string> containsFilter = x => x.Contains(filterParameter);

                switch (filterType)
                {
                    case "Starts with":
                        filteredInvitations = FilteredList(invitations, command[0], startsWithFlter, filteredInvitations);
                        break;
                    case "Ends with":
                        filteredInvitations = FilteredList(invitations, command[0], endsWithFilter, filteredInvitations);
                        break;
                    case "Length":
                        filteredInvitations = FilteredList(invitations, command[0], lengthFilter, filteredInvitations);
                        break;
                    case "Contains":
                        filteredInvitations = FilteredList(invitations, command[0], containsFilter, filteredInvitations);
                        break;
                }
                command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(" ", filteredInvitations));
        }

        static List<string> FilteredList(List<string> invitations, string command, Predicate<string> predicate, List<string> filteredInvitations)
        {
            for (int i = invitations.Count - 1; i >= 0; i--)
            {
                if (predicate(invitations[i]))
                {
                    switch (command)
                    {
                        case "Add filter":
                            filteredInvitations.Remove(invitations[i]);
                            break;
                        case "Remove filter":
                            filteredInvitations.Add(invitations[i]);
                            break;
                    }
                }
            }
            return filteredInvitations;
        }
    }
}
