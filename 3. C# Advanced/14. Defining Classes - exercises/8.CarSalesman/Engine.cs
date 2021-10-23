using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement)
           : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
          : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"  {this.Model}:");
            builder.AppendLine($"    Power: {this.Power}");
            builder.AppendLine($"    Displacement: {(this.Displacement == 0 ? "n/a" : this.Displacement.ToString())}");
            builder.AppendLine($"    Efficiency: {(this.Efficiency == null ? "n/a" : this.Efficiency.ToString())}");

            return builder.ToString();
        }
    }
}
