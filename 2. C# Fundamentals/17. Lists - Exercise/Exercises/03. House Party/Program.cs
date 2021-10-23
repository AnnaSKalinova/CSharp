using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());

            List<string> partyList = new List<string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string messages = Console.ReadLine();
                string[] token = messages.Split();
                bool isInTheList = false;
                switch (token[2])
                {
                    case "not":
                        for (int j = 0; j < partyList.Count; j++)
                        {
                            if (token[0] == partyList[j])
                            {
                                partyList.Remove(token[0]);
                                isInTheList = true;
                                break;
                            }
                        }
                        if (!isInTheList)
                        {
                            Console.WriteLine($"{token[0]} is not in the list!");
                        }
                        break;
                    default:
                        if (partyList.Count == 0)
                        {
                            partyList.Add(token[0]);
                            break;
                        }
                        for (int j = 0; j < partyList.Count; j++)
                        {
                            if (token[0] == partyList[j])
                            {
                                Console.WriteLine($"{token[0]} is already in the list!");
                                isInTheList = true;
                                break;
                            }
                        }
                        if (!isInTheList)
                        {
                            partyList.Add(token[0]);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join("\r\n", partyList));
        }
    }
}
