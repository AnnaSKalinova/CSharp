using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split().ToArray();

            var dict = new Dictionary<char, int>();

            foreach (var word in text)
            {
                foreach (var letter in word)
                {
                    if (!dict.ContainsKey(letter))
                    {
                        dict.Add(letter, 1);
                    }
                    else
                    {
                        dict[letter]++;
                    }
                }
            }

            foreach (var letter in dict)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
