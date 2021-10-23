using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }
            Box<string> box = new Box<string>(list);

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
