using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = ChangeNums(nums, n => n + 1);
                        break;
                    case "multiply":
                        nums = ChangeNums(nums, n => n * 2);
                        break;
                    case "subtract":
                        nums = ChangeNums(nums, n => n - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", nums));
                        break;
                }

                command = Console.ReadLine();
            }
        }

        static IEnumerable<int> ChangeNums(IEnumerable<int> collection, Func<int, int> func)
        {
            return collection.Select(n => func(n));
        }
    }
}
