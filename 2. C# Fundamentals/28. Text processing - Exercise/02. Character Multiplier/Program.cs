using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").ToArray();

            string firstString = input[0];
            string secondStrin = input[1];

            int sum = CharMultiplier(firstString, secondStrin);

            Console.WriteLine(sum);
        }

        static int CharMultiplier(string a, string b)
        {
            int sum = 0;

            int lenght = Math.Min(a.Length, b.Length);

            for (int i = 0; i < lenght; i++)
            {
                sum += (int)a[i] * (int)b[i];
            }

            if (a.Length > b.Length)
            {
                for (int j = b.Length; j < a.Length; j++)
                {
                    sum += (int)a[j];
                }
            }
            else if (a.Length < b.Length)
            {
                for (int j = a.Length; j < b.Length; j++)
                {
                    sum += (int)b[j];
                }
            }

            return sum;
        }
    }
}
