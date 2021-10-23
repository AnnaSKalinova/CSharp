using System;
using System.Linq;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split().ToArray();
            var nameFirstInput = firstInput[0] + " " + firstInput[1];
            var address = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(nameFirstInput, address);

            Console.WriteLine(string.Join(Environment.NewLine, firstTuple));

            var secondInput = Console.ReadLine().Split().ToArray();
            var nameSecondInut = secondInput[0];
            var amountOfBeer = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(nameSecondInut, amountOfBeer);

            Console.WriteLine(string.Join(Environment.NewLine, secondTuple));

            var thirdInput = Console.ReadLine().Split().ToArray();
            var inputInteger = int.Parse(thirdInput[0]);
            var inputDouble = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(inputInteger, inputDouble);

            Console.WriteLine(string.Join(Environment.NewLine, thirdTuple));

        }
    }
}
