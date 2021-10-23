using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                var currentNumber = phoneNumbers[i];

                if (currentNumber.Length == 7)
                {
                    try
                    {
                        StationaryPhone number = new StationaryPhone(currentNumber);
                        Console.WriteLine(number.CallNumber(currentNumber));
                }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (currentNumber.Length == 10)
                {
                    try
                    {
                        Smartphone number = new Smartphone(currentNumber);
                        Console.WriteLine(number.CallNumber(currentNumber));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            var urls = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < urls.Length; i++)
            {
                var currentUrl = urls[i];

                try
                {
                    Smartphone url = new Smartphone(currentUrl);
                    Console.WriteLine(url.Browse(currentUrl));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
