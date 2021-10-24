using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        private static object list;

        static void Main(string[] args)
        {
            List<string> tanks = Console.ReadLine().Split(", ").ToList();
            int commandsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(", ");

                switch (tokens[0])
                {
                    case "Add":
                        Add(tanks, tokens[1]);
                        break;
                    case "Remove":
                        Remove(tanks, tokens[1]);
                        break;
                    case "Remove At":
                        RemoveAt(tanks, int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        Insert(tanks, int.Parse(tokens[1]), tokens[2]);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", tanks));
        }

        static void Add(List<string> list, string name)
        {
            foreach (var currentTank in list)
            {
                if (currentTank == name)
                {
                    Console.WriteLine("Tank is already bought");
                    return;
                }
            }
            Console.WriteLine("Tank successfully bought");
            list.Add(name);
        }

        static void Remove(List<string> list, string name)
        {
            bool isTankFound = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == name)
                {
                    isTankFound = true;
                    Console.WriteLine("Tank successfully sold");
                    list.Remove(list[i]);
                }
            }
            if (!isTankFound)
            {
                Console.WriteLine("Tank not found");
            }
        }

        static void RemoveAt(List<string> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                Console.WriteLine("Tank successfully sold");
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }

        static void Insert(List<string> list, int index, string name)
        {
            if (index >= 0 && index < list.Count)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == name)
                    {
                        Console.WriteLine("Tank is already bought");
                        return;
                    }
                }
                Console.WriteLine("Tank successfully bought");
                list.Insert(index, name);
            }

            else
            {
                Console.WriteLine("Index out of range");
            }
        }
    }
}
