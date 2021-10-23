using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbersList = new List<int>();
            List<string> nonNumbersList = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    numbersList.Add(int.Parse(input[i].ToString()));
                }
                else
                {
                    nonNumbersList.Add(input[i].ToString());
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }

            string result = string.Empty;
            bool isTooLong = false; 

            for (int i = 0; i < takeList.Count; i++)
            {
                for (int j = 0; j < takeList[i]; j++)
                {
                    if (j > nonNumbersList.Count - 1)
                    {
                        isTooLong = true;
                        break;
                    }
                    result += nonNumbersList[j];
                }
                if (isTooLong)
                {
                    break;
                }
                else
                {
                    nonNumbersList.RemoveRange(0, takeList[i]);
                }

                if (nonNumbersList.Count > 0)
                {
                    for (int k = 0; k < skipList[i]; k++)
                    {
                        nonNumbersList.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
