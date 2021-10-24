using System;
using System.Linq;
using System.Text;

namespace _01._Nikulden_s_charity
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var command = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            while (!command.Contains("Finish"))
            {
                var action = command[0];
                sb.Clear();
                sb.Append(text);

                switch (action)
                {
                    case "Replace":
                        var currentChar = command[1];
                        var newChar = command[2];
                        while (sb.ToString().Contains(currentChar))
                        {
                            sb.Replace(currentChar, newChar);
                        }
                        text = sb.ToString();
                        Console.WriteLine(text);
                        break;
                    case "Cut":
                        var startIndex = int.Parse(command[1]);
                        var endIndex = int.Parse(command[2]);

                        if (startIndex < 0 || endIndex >= sb.ToString().Length)
                        {
                            Console.WriteLine("Invalid indexes!");
                            break;
                        }
                        else
                        {
                            text = sb.Remove(startIndex, endIndex - startIndex + 1).ToString();
                            Console.WriteLine(text);
                        }
                        break;
                    case "Make":
                        if (command[1] == "Upper")
                        {
                            text = sb.ToString().ToUpper();
                        }
                        else if (command[1] == "Lower")
                        {
                            text = sb.ToString().ToLower();
                        }
                        Console.WriteLine(text);
                        break;
                    case "Check":
                        var stringToContain = command[1];

                        if (sb.ToString().Contains(stringToContain))
                        {
                            Console.WriteLine($"Message contains {stringToContain}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {stringToContain}");
                        }
                        break;
                    case "Sum":
                        int sum = 0;
                        startIndex = int.Parse(command[1]);
                        endIndex = int.Parse(command[2]);

                        if (startIndex < 0 || endIndex >= sb.ToString().Length)
                        {
                            Console.WriteLine("Invalid indexes!");
                            break;
                        }

                        var substring = sb.ToString().Substring(startIndex, endIndex - startIndex + 1);
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += (int)substring[i];
                        }
                        Console.WriteLine(sum);
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
