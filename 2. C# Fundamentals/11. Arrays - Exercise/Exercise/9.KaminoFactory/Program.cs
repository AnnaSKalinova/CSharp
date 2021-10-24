using System;
using System.Linq;

namespace _9.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLenght = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int counter = 0;
            int maxCurrentCounter = 0;
            int maxTotalCounter = 0;
            int[] bestSequence = new int[sequenceLenght];
            int index = 0;
            int bestCurrentIndex = 0;
            int bestTotalIndex = 0;
            bool isPreviousZero = false;
            int sum = 0;
            int bestSum = 0;

            while (command != "Clone them!")
            {
                int[] sequence = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
                for (int i = sequence.Length - 1; i >= 0; i--)
                {
                    if (sequence[i] == 1)
                    {
                        if (isPreviousZero)
                        {
                            index = i;
                        }
                        counter++;
                        sum++;
                        isPreviousZero = false;
                    }
                    else
                    {
                        isPreviousZero = true;
                        if (counter >= maxCurrentCounter)
                        {
                            maxCurrentCounter = counter;
                            bestCurrentIndex = index;
                        }
                        counter = 0;
                    }
                }
                if (!isPreviousZero)
                {
                    if (counter >= maxCurrentCounter)
                    {
                        maxCurrentCounter = counter;
                        bestCurrentIndex = index;
                    }
                }
                if (maxCurrentCounter > maxTotalCounter)
                {
                    maxTotalCounter = maxCurrentCounter;
                    bestSequence = sequence;
                    bestTotalIndex = bestCurrentIndex;
                    bestSum = sum;
                }
                else if (maxCurrentCounter == maxTotalCounter && bestCurrentIndex < bestTotalIndex)
                {
                    maxTotalCounter = maxCurrentCounter;
                    bestSequence = sequence;
                    bestTotalIndex = bestCurrentIndex;
                    bestSum = sum;
                }
                else if (maxCurrentCounter == maxTotalCounter && bestCurrentIndex == bestTotalIndex && sum > bestSum)
                {
                    maxTotalCounter = maxCurrentCounter;
                    bestSequence = sequence;
                    bestTotalIndex = bestCurrentIndex;
                    bestSum = sum;
                }

                sum = 0;
                maxCurrentCounter = 0;
                bestCurrentIndex = 0;
                counter = 0;
                index = 0;
                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestTotalIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
