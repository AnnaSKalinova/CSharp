using System;
using System.Linq;
using System.Security.Cryptography;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine()
                .Split()
                .ToArray();
            var nameFirstInput = firstInput[0] + " " + firstInput[1];
            var address = firstInput[2];
            var town = firstInput[3];

            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(nameFirstInput, address, town);

            Console.WriteLine(firstThreeuple);

            var secondInput = Console.ReadLine()
                .Split()
                .ToArray();
            var nameSecondInput = secondInput[0];
            var litresOfBeer = int.Parse(secondInput[1]);
            bool isDrunk = false;
            if (secondInput[2] == "drunk")
            {
                isDrunk = true;
            }

            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(nameSecondInput, litresOfBeer, isDrunk);

            Console.WriteLine(secondThreeuple);

            var thirdInput = Console.ReadLine()
                .Split()
                .ToArray();
            var nameThirdInput = thirdInput[0];
            var accountBallance = double.Parse(thirdInput[1]);
            var bankName = thirdInput[2];

            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(nameThirdInput, accountBallance, bankName);

            Console.WriteLine(thirdThreeuple);
        }
    }
}
