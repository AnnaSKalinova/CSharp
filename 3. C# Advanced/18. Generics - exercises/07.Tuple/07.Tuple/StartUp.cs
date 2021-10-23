using System;
using System.Linq;

namespace _07.Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLineInput = Console.ReadLine()
                .Split()
                .ToArray();
            string name = firstLineInput[0] + " " + firstLineInput[1];
            string address = firstLineInput[2];

            Tuple<string, string> FirstTuple = new Tuple<string, string>(name, address);

            Console.WriteLine(FirstTuple);

            string[] secondLineInput = Console.ReadLine()
                .Split()
                .ToArray();
            name = secondLineInput[0];
            int litersOfBeer = int.Parse(secondLineInput[1]);

            Tuple<string, int> seconsTuple = new Tuple<string, int>(name, litersOfBeer);

            Console.WriteLine(seconsTuple);

            string[] thirdLineInput = Console.ReadLine()
                .Split()
                .ToArray();
            int num = int.Parse(thirdLineInput[0]);
            double secNum = double.Parse(thirdLineInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(num, secNum);

            Console.WriteLine(thirdTuple);
        }
    }
}
