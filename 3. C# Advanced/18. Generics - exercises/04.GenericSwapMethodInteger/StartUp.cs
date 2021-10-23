using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.Add(input);
            }
            Box<int> box = new Box<int>(list);

            var indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstIndex = indexes[0];
            var secondIndex = indexes[1];
            box.SwapElements(firstIndex, secondIndex);

            Console.WriteLine(string.Join(Environment.NewLine, box));
        }
    }
}
