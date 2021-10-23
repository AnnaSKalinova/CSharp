using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> combinedList = new List<int>();
            List<int> resultList = new List<int>();
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            if (firstList.Count > secondList.Count)
            {
                for (int i = 0; i < secondList.Count; i++)
                {
                    combinedList.Add(firstList[i]);
                    combinedList.Add(secondList[secondList.Count - 1 - i]);
                }
                firstList.RemoveRange(0, secondList.Count);
                minNumber = Math.Min(firstList[0], firstList[1]);
                maxNumber = Math.Max(firstList[0], firstList[1]);
            }
            else
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    combinedList.Add(firstList[i]);
                    combinedList.Add(secondList[secondList.Count - 1 - i]);
                }
                secondList.RemoveRange(secondList.Count - firstList.Count, firstList.Count);
                minNumber = Math.Min(secondList[0], secondList[1]);
                maxNumber = Math.Max(secondList[0], secondList[1]);
            }

            for (int i = 0; i < combinedList.Count; i++)
            {
                if (combinedList[i] > minNumber && combinedList[i] < maxNumber)
                {
                    resultList.Add(combinedList[i]);
                }
            }

            resultList.Sort();

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
