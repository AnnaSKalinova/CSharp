using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            List<string> elements = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var element = Console.ReadLine();
                elements.Add(element);
            }

            Box<string> box = new Box<string>(elements);

            var elementToCompare = Console.ReadLine();
            var count = box.CountOfGraterValues(elementToCompare);

            Console.WriteLine(count);
        }
    }
}
