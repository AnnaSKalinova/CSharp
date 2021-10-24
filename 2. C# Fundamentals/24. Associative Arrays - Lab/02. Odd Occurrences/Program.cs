using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split().ToArray();

            var dict = new Dictionary<string, int>();

            foreach (var element in inputArr)
            {
                string wordToLower = element.ToLower();

                if (!dict.ContainsKey(wordToLower))
                {
                    dict.Add(wordToLower, 1);
                }
                else
                {
                    dict[wordToLower]++;
                }
            }

            foreach (var word in dict)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
