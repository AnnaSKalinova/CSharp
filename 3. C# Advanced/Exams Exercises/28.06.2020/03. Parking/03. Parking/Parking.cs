using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            List<Car> data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public List<Car> Add(Car car)
        {
            data.Add(car);
            return data;
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isRemoved = false;
            foreach (var car in data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    data.Remove(car);
                    isRemoved = true;
                }
            }
            return isRemoved;
        }

        public Car GetLatestCar()
        {
            Car latestCar = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car givenCar = data.Where(x => x.Manufacturer == manufacturer).Where(x => x.Model == model).FirstOrDefault();
            return givenCar;
        }

        public int Count()
        {
            int count = data.Count();
            return count;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.Append(car);
            }
            return sb.ToString();
        }
    }
}
