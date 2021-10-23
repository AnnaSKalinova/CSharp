using System;
using System.Linq;

namespace _5._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split().ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, inputArr.Where(x => x.Length % 2 == 0).ToArray()));
        }
    }
}
