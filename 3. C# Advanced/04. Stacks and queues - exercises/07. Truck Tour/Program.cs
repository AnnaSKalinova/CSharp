using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfPetrolPumps = int.Parse(Console.ReadLine());

            var originalQueue = new Queue<int[]>();
            var queue = new Queue<int[]>();
            int counter = 0;

            for (int i = 0; i < numOfPetrolPumps; i++)
            {
                var inputPair = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(inputPair);
            }

            while (true)
            {
                var petrolLeft = 0;
                bool isOrderRight = true;

                for (int i = 0; i < numOfPetrolPumps; i++)
                {
                    var currentPair = queue.Dequeue();
                    var amountOfPetrol = currentPair[0];
                    var distance = currentPair[1];
                    
                    petrolLeft += amountOfPetrol;
                    
                    if (petrolLeft >= distance)
                    {
                        petrolLeft -= distance;
                    }
                    else
                    {
                        isOrderRight = false;
                    }
                    queue.Enqueue(currentPair);
                }
                if (isOrderRight)
                {
                    Console.WriteLine(counter);
                    break;
                }

                counter++;
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}
