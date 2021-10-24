using System;
using System.Linq;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friendsList = Console.ReadLine().Split(", ").ToArray();
            string command = Console.ReadLine();

            while (command != "Report")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Blacklist":
                        Blacklist(friendsList, tokens[1]);
                        break;
                    case "Error":
                        Error(friendsList, int.Parse(tokens[1]));
                        break;
                    case "Change":
                        Change(friendsList, int.Parse(tokens[1]), tokens[2]);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            int blacklistedNamesCounter = 0;
            int lostNamesCounter = 0;
            foreach (var name in friendsList)
            {
                if (name == "Blacklisted")
                {
                    blacklistedNamesCounter++;
                }
                else if (name == "Lost")
                {
                    lostNamesCounter++;
                }
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNamesCounter}");
            Console.WriteLine($"Lost names: {lostNamesCounter}");
            Console.WriteLine(string.Join(" ", friendsList));
        }

        static void Blacklist(string[] list, string name)
        {
            bool isNameFound = false;
            for (int i = 0; i < list.Length; i++)
            {
                if (name == list[i])
                {
                    list[i] = "Blacklisted";
                    isNameFound = true;
                    Console.WriteLine($"{name} was blacklisted.");
                    return;
                }
            }
            if (!isNameFound)
            {
                Console.WriteLine($"{name} was not found.");
            }
        }

        static void Error(string[] list, int index)
        {
            if (!(list[index] == "Blacklisted" || list[index] == "Lost"))
            {
                Console.WriteLine($"{list[index]} was lost due to an error.");
                list[index] = "Lost";
            }
        }

        static void Change(string[] list, int index, string newName)
        {
            if (index >= 0 && index < list.Length)
            {
                Console.WriteLine($"{list[index]} changed his username to {newName}.");
                list[index] = newName;
            }
        }
    }
}
