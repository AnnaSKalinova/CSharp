using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split('|');

            int health = 100;
            int bitcoins = 0;
            string command = string.Empty;
            int number = 0;
            int counter = 0;

            foreach (var room in inputArr)
            {
                counter++;
                string[] rooms = room.Split();
                command = rooms[0];
                number = int.Parse(rooms[1]);

                switch (command)
                {
                    case "potion":
                        if (health  + number > 100)
                        {
                            number = 100 - health;
                            health = 100;
                        }
                        else
                        {
                            health += number;
                        }
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:
                        health -= number;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {counter}");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
