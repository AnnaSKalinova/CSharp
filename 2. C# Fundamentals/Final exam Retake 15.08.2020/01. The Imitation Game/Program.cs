using System;
using System.Linq;
using System.Text;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string[] instructions = Console.ReadLine().Split('|').ToArray();

            StringBuilder sb = new StringBuilder();

            while (!instructions.Contains("Decode"))
            {
                string action = instructions[0];

                switch (action)
                {
                    case "Move":
                        sb.Append(encryptedMessage);
                        int countOfCharsToMove = int.Parse(instructions[1]);
                        string charsToMove = encryptedMessage.Substring(0, countOfCharsToMove);
                        sb.Remove(0, countOfCharsToMove);
                        sb.Append(charsToMove);
                        encryptedMessage = sb.ToString();
                        break;
                    case "Insert":
                        sb.Append(encryptedMessage);
                        int index = int.Parse(instructions[1]);
                        string value = instructions[2];
                        sb.Insert(index, value);
                        encryptedMessage = sb.ToString();
                        break;
                    case "ChangeAll":
                        sb.Append(encryptedMessage);
                        string substring = instructions[1];
                        string replacement = instructions[2];
                        sb.Replace(substring, replacement);
                        encryptedMessage = sb.ToString();
                        break;
                }

                sb.Clear();
                instructions = Console.ReadLine().Split('|').ToArray();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
