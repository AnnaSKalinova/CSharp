using System;
using System.Text;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();
            string[] instructions = Console.ReadLine().Split(">>>");

            StringBuilder sb = new StringBuilder();
            string activationKey = rawActivationKey;
            sb.Append(activationKey);

            while (instructions[0] != "Generate")
            {
                switch (instructions[0])
                {
                    case "Contains":
                        string substring = instructions[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(instructions[2]);
                        int endIndex = int.Parse(instructions[3]);

                        if (instructions[1] == "Lower")
                        {
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                sb[i] = char.Parse(sb[i].ToString().ToLower());
                            }
                        }
                        else if (instructions[1] == "Upper")
                        {

                            for (int i = startIndex; i < endIndex; i++)
                            {
                                sb[i] = char.Parse(sb[i].ToString().ToUpper());
                            }
                        }
                        activationKey = sb.ToString();
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(instructions[1]);
                        endIndex = int.Parse(instructions[2]);

                        sb = sb.Remove(startIndex, endIndex - startIndex);

                        activationKey = sb.ToString();
                        Console.WriteLine(activationKey);
                        break;
                }

                instructions = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
