using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStrings = int.Parse(Console.ReadLine());

            int[] output = new int[numOfStrings];

            for (int i = 0; i < numOfStrings; i++)
            {
                string input = Console.ReadLine();
                int sum = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    bool isVowel = false;

                    switch (input[j])
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':
                            isVowel = true;
                            break;
                        default:
                            break;
                    }
                    if (isVowel)
                    {
                        sum += (input[j] * input.Length);
                    }
                    else
                    {
                        sum += (input[j] / input.Length);
                    }
                }
                output[i] = sum;
            }
            Array.Sort(output);
            
            Console.WriteLine(string.Join("\r\n", output));
        }
    }
}
