using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int counOfInts = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < counOfInts; i++)
            {
                var currInt = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(currInt))
                {
                    dictionary.Add(currInt, 0);
                }
                dictionary[currInt]++;
            }

            foreach (var number in dictionary
                .Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
