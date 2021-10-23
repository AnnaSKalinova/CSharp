using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfCommands = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, string>();

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] inputCommand = Console.ReadLine().Split().ToArray();
                
                switch (inputCommand[0])
                {
                    case "register":
                        string username = inputCommand[1];
                        string licensePlateNumber = inputCommand[2];

                        if (dict.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                            break;
                        }
                        else
                        {
                            dict.Add(username, licensePlateNumber);
                            Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                        }
                        break;
                    case "unregister":
                        username = inputCommand[1];

                        if (!dict.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            dict.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var car in dict)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
