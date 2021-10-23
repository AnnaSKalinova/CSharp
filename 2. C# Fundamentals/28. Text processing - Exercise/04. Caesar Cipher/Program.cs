using System;
using System.Linq;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (char letter in input)
            {
                sb.Append((char)(letter + 3));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
