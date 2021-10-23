using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine();

            var stack = new Stack<char>();
            bool isSame = true;

            if (sequence.Length % 2 != 0)
            {
                isSame = false;
            }
            else
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == '{' || sequence[i] == '(' || sequence[i] == '[')
                    {
                        stack.Push(sequence[i]);
                    }
                    else
                    {
                        if (stack.Any())
                        {
                            if (sequence[i] == '}')
                            {
                                if (stack.Peek() != '{')
                                {
                                    isSame = false;
                                    break;
                                }
                            }
                            if (sequence[i] == ')')
                            {
                                if (stack.Peek() != '(')
                                {
                                    isSame = false;
                                    break;
                                }
                            }
                            if (sequence[i] == ']')
                            {
                                if (stack.Peek() != '[')
                                {
                                    isSame = false;
                                    break;
                                }
                            }
                        }
                        stack.Pop();
                    }
                }
            }
            
            if (isSame)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
