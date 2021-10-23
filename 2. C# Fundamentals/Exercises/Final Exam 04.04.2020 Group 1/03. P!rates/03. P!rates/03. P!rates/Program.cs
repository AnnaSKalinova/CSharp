using System;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        class Pirates
        {
            public string PirateName { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }

            public Pirates(string name, int population, int gold)
            {
                this.PirateName = name;
                this.Population = population;
                this.Gold = gold;
            }
        }
    }
}
