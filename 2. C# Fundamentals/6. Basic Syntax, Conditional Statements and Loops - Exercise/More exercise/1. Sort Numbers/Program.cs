using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                input.Add(int.Parse(Console.ReadLine()));
            }

            while (input.Count > 0)
            {
                int currentMaxNum = input.Max();
                Console.WriteLine(currentMaxNum);
                input.Remove(input.Max());
            }
        }
    }
}
