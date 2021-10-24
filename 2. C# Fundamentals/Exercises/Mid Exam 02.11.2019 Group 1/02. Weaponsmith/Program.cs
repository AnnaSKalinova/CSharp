using System;
using System.Linq;

namespace _02._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] particles = Console.ReadLine().Split('|').ToArray();
            string command = Console.ReadLine();


            while (command != "Done")
            {
                string[] tokens = command.Split();
                switch (tokens[1])
                {
                    case "Left":
                        MoveLeft(particles, int.Parse(tokens[2]));
                        break;
                    case "Right":
                        MoveRight(particles, int.Parse(tokens[2]));
                        break;
                    case "Even":
                        CheckEven(particles);
                        break;
                    case "Odd":
                        CheckOdd(particles);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", particles)}!");
        }

        static void MoveLeft(string[] array, int index)
        {
            if (index >= 1 && index < array.Length)
            {
                string current = array[index - 1];
                array[index - 1] = array[index];
                array[index] = current;
            }
        }

        static void MoveRight(string[] array, int index)
        {
            if (index >= 0 && index < array.Length - 1)
            {
                string current = array[index + 1];
                array[index + 1] = array[index];
                array[index] = current;
            }
        }

        static void CheckEven(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();
        }

        static void CheckOdd(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
