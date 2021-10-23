using System;
using System.Linq;

namespace _9._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int[] bestSequence = new int[lenght];
            int currentIndex = 0;
            int bestSum = 0;
            int bestIndex = 0;
            int maxTotalCounter = 0;

            while (command != "Clone them!")
            {
                int[] currentSequence = command.Split("!").Select(int.Parse).ToArray();

                currentIndex = 0;
                int sum = 0;
                int counter = 0;
                int maxCurrentCounter = 0;

                for (int i = currentSequence.Length - 1; i >= 0; i--)
                {
                    if (currentSequence[i] == 1)
                    {
                        sum++;
                        counter++;

                        if (counter >= maxCurrentCounter)
                        {
                            maxCurrentCounter = counter;
                            currentIndex = i + counter - 1;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                if (maxCurrentCounter > maxTotalCounter)
                {
                    maxTotalCounter = maxCurrentCounter;
                    bestSequence = currentSequence;
                    bestSum = sum;
                    bestIndex = currentIndex;
                }
                else if (maxCurrentCounter == maxTotalCounter && currentIndex < bestIndex)
                {
                    maxTotalCounter = maxCurrentCounter;
                    bestSequence = currentSequence;
                    bestSum = sum;
                    bestIndex = currentIndex;
                }
                else if (maxCurrentCounter == maxTotalCounter && currentIndex == bestIndex)
                {
                    if (sum > bestSum)
                    {
                        maxTotalCounter = maxCurrentCounter;
                        bestSequence = currentSequence;
                        bestSum = sum;
                        bestIndex = currentIndex;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
