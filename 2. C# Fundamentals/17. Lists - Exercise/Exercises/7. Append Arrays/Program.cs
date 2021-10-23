using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            string output = string.Empty;

            for (int i = inputList.Count - 1; i >= 0; i--)
            {
                string[] values = inputList[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < values.Length; j++)
                {
                    output += values[j] + " ";
                }
            }

            Console.WriteLine(output);
        }
    }
}
