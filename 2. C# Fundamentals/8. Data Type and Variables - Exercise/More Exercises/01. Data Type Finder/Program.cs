using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string dataType = string.Empty;

            while (input != "END")
            {
                if (input == "true" || input == "false")
                {
                    dataType = "boolean";
                }
                else if (input[0] >= 'a' && input[0] <= 'z' || input[0] >= 'A' && input[0] <= 'Z')
                {
                    if (input.Length == 1)
                    {
                        dataType = "character";
                    }
                    else
                    {
                        dataType = "string";
                    }
                }
                else if (input[0] >= '1' && input[0] <= '9' || input[0] <= '-')
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '.')
                        {
                            dataType = "floating point";
                            break;
                        }
                        else
                        {
                            dataType = "integer";
                        }
                    }
                }
                Console.WriteLine($"{input} is {dataType} type");

                input = Console.ReadLine();
            }
        }
    }
}
