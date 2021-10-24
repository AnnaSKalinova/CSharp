using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!").ToList();

            string[] command = Console.ReadLine().Split();
            
            while (command[0] != "Go")
            {
                bool isExist = false;
                string action = command[0];
                string item = command[1];

                switch (action)
                {
                    case "Urgent":
                        foreach (var element in groceries)
                        {
                            if (element == item)
                            {
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist == false)
                        {
                            groceries.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        foreach (var element in groceries)
                        {
                            if (element == item)
                            {
                                groceries.Remove(item);
                            }
                        }
                        break;
                    case "Correct":
                        string newItem = command[2];
                        for (int i = 0; i < groceries.Count; i++)
                        {
                            if (groceries[i] == item)
                            {
                                groceries[i] = newItem;
                            }
                        }
                        break;
                    case "Rearrange":
                        foreach (var element in groceries)
                        {
                            if (element == item)
                            {
                                groceries.Remove(element);
                                groceries.Add(element);
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
