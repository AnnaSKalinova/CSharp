using System;
using System.Linq;
using System.Text;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string[] command = Console.ReadLine().Split();

            while (!command.Contains("Complete"))
            {
                StringBuilder sb = new StringBuilder();

                switch (command[0])
                {
                    case "Make":
                        if (command[1] == "Upper")
                        {
                            sb.Append(email.ToUpper());
                        }
                        else if (command[1] == "Lower")
                        {
                            sb.Append(email.ToLower());
                        }
                        email = sb.ToString();
                        Console.WriteLine(email);
                        break;
                    case "GetDomain":
                        int countOsChars = int.Parse(command[1]);
                        for (int i = email.Length - countOsChars; i < email.Length; i++)
                        {
                            sb.Append(email[i]);
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                    case "GetUsername":
                        bool isChar = false;
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i] == '@')
                            {
                                isChar = true;
                                break;
                            }
                            sb.Append(email[i]);
                        }
                        if (isChar)
                        {
                            Console.WriteLine(sb.ToString());
                        }
                        else
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        }
                        break;
                    case "Replace":
                        for (int i = 0; i < email.Length; i++)
                        {
                            if (email[i] == char.Parse(command[1]))
                            {
                                sb.Append('-');
                            }
                            else
                            {
                                sb.Append(email[i]);
                            }
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                    case "Encrypt":
                        for (int i = 0; i < email.Length; i++)
                        {
                            Console.Write((int)email[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                }

                command = Console.ReadLine().Split();
            }

        }
    }
}
