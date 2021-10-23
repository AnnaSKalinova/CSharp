using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;
        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
