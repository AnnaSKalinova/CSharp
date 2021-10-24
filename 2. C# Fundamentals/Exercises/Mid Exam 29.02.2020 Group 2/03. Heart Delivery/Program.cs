using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            int countValentinesDayHouses = 0;
            int cupidsLastPosition = 0;

            while (command != "Love!")
            {
                string[] tokens = command.Split();
                int position = int.Parse(tokens[1]);

                int currentPosition = cupidsLastPosition + position;

                if (currentPosition > neighborhood.Count - 1)
                {
                    currentPosition = 0;
                }

                neighborhood[currentPosition] -= 2;

                if (neighborhood[currentPosition] == -2)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                    neighborhood[currentPosition] += 2;
                }
                else if (neighborhood[currentPosition] == 0)
                {
                    countValentinesDayHouses++;
                    Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                }

                cupidsLastPosition = currentPosition;

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {cupidsLastPosition}.");
            if (countValentinesDayHouses == neighborhood.Count)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Count - countValentinesDayHouses} places.");
            }
        }
    }
}
