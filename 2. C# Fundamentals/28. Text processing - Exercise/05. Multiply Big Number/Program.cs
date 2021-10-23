using System;
using System.Resources;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());

            int remainder = 0;
            int digitToAdd = 0;

            StringBuilder sb = new StringBuilder();

            if (number == "0" || digit == 0)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int result = int.Parse(number[i].ToString()) * digit;

                if (result.ToString().Length == 2)
                {
                    digitToAdd = int.Parse((result + remainder).ToString());

                }
                else
                {
                    digitToAdd = result + remainder;
                    remainder = 0;
                }

                if (digitToAdd.ToString().Length == 2)
                {
                    remainder = int.Parse(digitToAdd.ToString()[0].ToString());
                    digitToAdd = int.Parse(digitToAdd.ToString()[1].ToString());
                }

                sb.Append((digitToAdd).ToString());

                if (i == 0)
                {
                    if (remainder != 0)
                    {
                        sb.Append(remainder).ToString();
                    }
                    break;
                }
            }
            
            string revercedResult = string.Empty;
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                revercedResult += sb[i];
            }

            Console.WriteLine(revercedResult.TrimStart('0'));
        }
    }
}
