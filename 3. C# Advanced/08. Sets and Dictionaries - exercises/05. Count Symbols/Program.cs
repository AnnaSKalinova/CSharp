using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var dict = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dict.ContainsKey(text[i]))
                {
                    dict.Add(text[i], 0);
                }
                dict[text[i]]++;
            }

            foreach (var letter in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
