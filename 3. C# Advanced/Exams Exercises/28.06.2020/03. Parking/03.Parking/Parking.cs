using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> data;

        private Parking()
        {
            this.data = new List<Car>();
        }
        public Parking(string type, int capacity)
            : this()
        {
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isRemoved = false;
            foreach (var car in this.data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    data.Remove(car);
                    isRemoved = true;
                    return isRemoved;
                }
            }
            return isRemoved;
        }

        public Car GetLatestCar()
        {
            Car latestCar = this.data.OrderByDescending(x => x.Year).FirstOrDefault();
            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car givenCar = data.Where(x => x.Manufacturer == manufacturer).Where(x => x.Model == model).FirstOrDefault();
            return givenCar;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}
