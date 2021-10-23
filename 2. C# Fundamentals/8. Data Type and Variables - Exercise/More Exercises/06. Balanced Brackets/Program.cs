using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            bool isBalanced = false;
            string bracked = string.Empty;
            int openingBracketCounter = 0;
            int closingBracketCounter = 0;

            for (int i = 0; i < countOfLines; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    bracked = "(";
                    isBalanced = false;
                    openingBracketCounter++;
                }
                else if (input == ")")
                {
                    closingBracketCounter++;
                    if (bracked == "(")
                    {
                        isBalanced = true;
                        bracked = string.Empty;
                    }
                }
            }
            if (isBalanced && openingBracketCounter == closingBracketCounter)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
