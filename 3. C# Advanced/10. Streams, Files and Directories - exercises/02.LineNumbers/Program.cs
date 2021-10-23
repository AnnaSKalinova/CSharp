using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].ToLower();
                int lettersCount = 0;
                int countOfPunctuationMarks = 0;
                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (Char.IsLetter(currentLine[j]))
                    {
                        lettersCount++;
                    }
                    else
                    {
                        if (currentLine[j] != ' ')
                        {
                            countOfPunctuationMarks++;
                        }
                    } 
                }
                result[i] = $"Line {i + 1}: {lines[i]}({lettersCount})({countOfPunctuationMarks})";
            }
            File.WriteAllLines("../../../output.txt", result);
        }
    }
}
