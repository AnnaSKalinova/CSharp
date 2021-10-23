using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace _8.CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            this.Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{this.Model}:");
            builder.Append(this.Engine);
            builder.AppendLine($"  Weight: {(this.Weight == 0 ? "n/a" : this.Weight.ToString())}");
            builder.Append($"  Color: {(this.Color == null ? "n/a" : this.Color)}");

            return builder.ToString();
        }
    }
}
