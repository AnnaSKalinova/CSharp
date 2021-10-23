using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPokePower = int.Parse(Console.ReadLine());
            int mDistance = int.Parse(Console.ReadLine());
            int yExhaustionFactor = int.Parse(Console.ReadLine());

            int originalNPokePower = nPokePower;
            int countOfTargets = 0;

            while (nPokePower >= mDistance)
            {
                nPokePower -= mDistance;
                countOfTargets++;
                if (nPokePower == 0.5 * originalNPokePower)
                {
                    if (yExhaustionFactor != 0)
                    {
                        nPokePower /= yExhaustionFactor;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(nPokePower);
            Console.WriteLine(countOfTargets);
        }
    }
}
