using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < numOfLines; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "1":
                        text += command[1];
                        stack.Push(text);
                        break;
                    case "2":
                        int startIndex = text.Length - int.Parse(command[1]);
                        text = text.Remove(startIndex);
                        stack.Push(text);
                        break;
                    case "3":
                        int position = int.Parse(command[1]) - 1;
                        Console.WriteLine(text[position]);
                        break;
                    case "4":
                        stack.Pop();
                        if (stack.Any())
                        {
                            text = stack.Peek();
                        }
                        else
                        {
                            text = string.Empty;
                        }
                        break;
                }
            }
        }
    }
}
