using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                string barcode = Console.ReadLine();

                string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(barcode);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < barcode.Length; j++)
                {
                    if (char.IsDigit(barcode[j]))
                    {
                        sb.Append(barcode[j]);
                    }
                }

                if (sb.Length > 0)
                {
                    Console.WriteLine($"Product group: {sb}"); ;
                }
                else
                {
                    Console.WriteLine($"Product group: 00");
                }
            }
        }
    }
}
