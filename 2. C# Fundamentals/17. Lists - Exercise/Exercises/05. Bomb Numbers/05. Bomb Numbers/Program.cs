using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNumber = bombArray[0];
            int power = bombArray[1];

            while (inputList.Contains(bombNumber))
            {
                for (int i = 0; i < inputList.Count; i++)
                {
                    int leftIndex = 0;
                    int rightIndex = 0;

                    if (inputList[i] == bombNumber)
                    {
                        leftIndex = i - power;
                        rightIndex = i + power;

                        if (leftIndex < 0)
                        {
                            leftIndex = 0;
                        }
                        if (rightIndex > inputList.Count - 1)
                        {
                            rightIndex = inputList.Count - 1;
                        }

                        inputList.RemoveRange(leftIndex, (rightIndex - leftIndex + 1));
                    }
                }
            }

            Console.WriteLine(inputList.Sum());
        }
    }
}
