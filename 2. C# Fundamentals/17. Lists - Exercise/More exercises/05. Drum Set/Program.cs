using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> qualityOfDrums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string hitPower = Console.ReadLine();

            List<int> initialQualityOfDrums = qualityOfDrums.ToList();
            int priceOfDrum = 0;
            
            while (hitPower != "Hit it again, Gabsy!")
            {
                for (int i = 0; i < qualityOfDrums.Count; i++)
                {
                    qualityOfDrums[i] -= int.Parse(hitPower);
                    if (qualityOfDrums[i] <= 0)
                    {
                        priceOfDrum = initialQualityOfDrums[i] * 3;
                        if (savings >= priceOfDrum)
                        {
                            qualityOfDrums[i] = initialQualityOfDrums[i];
                            savings -= priceOfDrum;
                        }
                        else
                        {
                            qualityOfDrums.RemoveAt(i);
                            initialQualityOfDrums.RemoveAt(i);
                            i--;
                        }
                    }
                }

                hitPower = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", qualityOfDrums));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
