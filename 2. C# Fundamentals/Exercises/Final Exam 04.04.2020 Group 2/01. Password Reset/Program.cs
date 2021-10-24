using System;
using System.Linq;
using System.Text;

namespace Problem_1._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawPassword = Console.ReadLine();
            string[] command = Console.ReadLine().Split().ToArray();

            while (!command.Contains("Done"))
            {
                switch (command[0])
                {
                    case "TakeOdd":
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < rawPassword.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                sb.Append(rawPassword[i]);
                            }
                        }
                        rawPassword = sb.ToString();

                        Console.WriteLine(rawPassword);
                        break;
                    case "Cut":
                        rawPassword = rawPassword.Remove(int.Parse(command[1]), int.Parse(command[2]));

                        Console.WriteLine(rawPassword);
                        break;
                    case "Substitute":
                        if (rawPassword.Contains(command[1]))
                        {
                            rawPassword = rawPassword.Replace(command[1], command[2]);

                            Console.WriteLine(rawPassword);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"Your password is: {rawPassword}");
        }
    }
}
