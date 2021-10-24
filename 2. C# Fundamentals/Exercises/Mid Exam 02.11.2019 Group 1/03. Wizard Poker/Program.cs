using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputDeck = Console.ReadLine().Split(':').ToList();
            string command = Console.ReadLine();

            List<string> outputDeck = new List<string>();

            while (command != "Ready")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        Add(inputDeck, tokens[1], outputDeck);
                        break;
                    case "Insert":
                        Insert(inputDeck, tokens[1], int.Parse(tokens[2]), outputDeck);
                        break;
                    case "Remove":
                        Remove(outputDeck, tokens[1]);
                        break;
                    case "Swap":
                        Swap(outputDeck, tokens[1], tokens[2]);
                        break;
                    case "Shuffle":
                        Shuffle(outputDeck);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", outputDeck));
        }

        static void Add(List<string> inputList, string cardName, List<string> outputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] == cardName)
                {
                    outputList.Add(cardName);
                    return;
                }
            }
            Console.WriteLine("Card not found.");
        }

        static void Insert(List<String> inputList, string cardName, int index, List<String> outputList)
        {
            if (index >=0 && index < inputList.Count && index < outputList.Count)
            {
                for (int i = 0; i < inputList.Count; i++)
                {
                    if (inputList[i] == cardName)
                    {
                        outputList.Insert(index, cardName);
                        return;
                    }
                }
            }
            
            Console.WriteLine("Error!");
        }

        static void Remove(List<String> list, string cardName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == cardName)
                {
                    list.Remove(cardName);
                    return;
                }
            }
            Console.WriteLine("Card not found.");
        }

        static void Swap(List<String> list, string cardName1, string cardName2)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == cardName1)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] == cardName2)
                        {
                            list.RemoveAt(i);
                            list.Insert(i, cardName2);
                            list.RemoveAt(j);
                            list.Insert(j, cardName1);
                            return;
                        }
                    }
                }
            }
        }

        static void Shuffle(List<string> list)
        {
            list.Reverse();
        }
    }
}
