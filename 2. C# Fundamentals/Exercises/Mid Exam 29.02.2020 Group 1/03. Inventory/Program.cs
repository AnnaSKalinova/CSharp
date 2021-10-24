using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();

            string[] command = Console.ReadLine().Split(" - ");

            while (command[0] != "Craft!")
            {
                string action = command[0];
                string item = command[1];
                bool isExisting = false;

                switch (action)
                {
                    case "Collect":
                        foreach (var element in journal)
                        {
                            if (element == item)
                            {
                                isExisting = true;
                            }
                        }
                        if (isExisting == false)
                        {
                            journal.Add(item);
                        }
                        break;
                    case "Drop":
                        foreach (var element in journal)
                        {
                            if (element == item)
                            {
                                journal.Remove(item);
                                break;
                            }
                        }
                        break;
                    case "Combine Items":
                        string[] combinedItems = item.Split(":");
                        string oldItem = combinedItems[0];
                        string newItem = combinedItems[1];

                        for (int i = 0; i < journal.Count; i++)
                        {
                            if (journal[i] == oldItem)
                            {
                                journal.Insert(i + 1, newItem);
                            }
                        }
                        break;
                    case "Renew":
                        foreach (var element in journal)
                        {
                            if (element == item)
                            {
                                journal.Remove(item);
                                journal.Add(item);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split(" - ");
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
