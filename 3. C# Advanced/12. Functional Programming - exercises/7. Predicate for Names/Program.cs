using System;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split()
                .ToArray();

            Func<string, bool> nameFilter = x => x.Length <= namesLenght;

            names = names.Where(nameFilter).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
