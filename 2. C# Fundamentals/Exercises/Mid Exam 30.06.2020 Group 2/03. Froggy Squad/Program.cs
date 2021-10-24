using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split().ToList();
            string[] command = Console.ReadLine().Split();

            while (!command.Contains("Print"))
            {
                switch (command[0])
                {
                    case "Join":
                        Join(frogs, command[1]);
                        break;
                    case "Jump":
                        Jump(frogs, command[1], int.Parse(command[2]));
                        break;
                    case "Dive":
                        Dive(frogs, int.Parse(command[1]));
                        break;
                    case "First":
                        FirstCount(frogs, int.Parse(command[1]));
                        break;
                    case "Last":
                        LastCount(frogs, int.Parse(command[1]));
                        break;
                }

                command = Console.ReadLine().Split();
            }

            if (command.Contains("Reversed"))
            {
                frogs.Reverse();
            }

            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
        }

        static void Join(List<string> list, string name)
        {
            list.Add(name);
        }

        static void Jump(List<string> list, string name, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.Insert(index, name);
            }
        }

        static void Dive(List<string> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
            }
        }

        static void FirstCount(List<string> list, int count)
        {
            if (count >= list.Count)
            {
                count = list.Count;
            }
            for (int i = 0; i < count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void LastCount(List<string> list, int count)
        {
            if (count >= list.Count)
            {
                count = list.Count;
            }
            for (int i = list.Count - count; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
