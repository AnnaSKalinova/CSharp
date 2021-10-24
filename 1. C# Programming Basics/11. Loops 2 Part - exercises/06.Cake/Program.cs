using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int cake = widht * lenght;
            string peacesTaken = Console.ReadLine();
            bool isCakeFinished = false;

            while (peacesTaken != "STOP")
            {
                cake -= int.Parse(peacesTaken);

                if (cake <= 0)
                {
                    isCakeFinished = true;
                    break;
                }
                peacesTaken = Console.ReadLine();
            }

            if (isCakeFinished)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cake} pieces are left.");
            }
        }
    }
}
