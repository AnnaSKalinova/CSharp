using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int strengthOfExplosion = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strengthOfExplosion += int.Parse(input[i + 1].ToString());
                    sb.Append(input[i]);
                }
                else if (strengthOfExplosion > 0)
                {
                    strengthOfExplosion--;
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
