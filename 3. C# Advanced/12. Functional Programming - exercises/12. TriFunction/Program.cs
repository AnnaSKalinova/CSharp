using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split()
                .ToArray();
            Func<string, int, bool> someFunc = (name, num) => name.ToCharArray().Select(ch => (int)ch).Sum() >= num;

            Func<string[], Func<string, int, bool>, string> firstValidName = (names, someFunc) => names.FirstOrDefault(x => someFunc(x, n));
            string targetName = firstValidName(names, someFunc);

            Console.WriteLine(targetName);
        }
    }
}
