using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();
            int numToDivide = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> func = x => x
                .Where(y => y % numToDivide != 0).ToList();

            Console.WriteLine(string.Join(" ", func(collection)));
        }
    }
}
