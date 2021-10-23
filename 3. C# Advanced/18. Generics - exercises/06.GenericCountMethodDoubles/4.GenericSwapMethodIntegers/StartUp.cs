using System;
using System.Collections.Generic;

namespace _6.GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> numbers = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var element = double.Parse(Console.ReadLine());
                numbers.Add(element);
            }

            Box<double> box = new Box<double>(numbers);

            var elementToComape = double.Parse(Console.ReadLine());
            var count = box.CountOfGreaterElements(elementToComape);

            Console.WriteLine(count);
        }
    }
}
