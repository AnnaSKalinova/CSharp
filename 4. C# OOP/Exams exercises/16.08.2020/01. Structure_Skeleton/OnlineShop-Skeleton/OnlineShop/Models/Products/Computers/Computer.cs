using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList().AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price => base.Price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Select(p => p.OverallPerformance).Average()}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }
        public IComponent RemoveComponent(string componentType)
        {
            if (this.Components == null || !this.Components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            var removedComponent = components.FirstOrDefault(c => c.GetType().Name == componentType);
            components.Remove(removedComponent);

            return removedComponent;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }


        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals == null || !this.Peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            var removedPeripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            peripherals.Remove(removedPeripheral);

            return removedPeripheral;
        }
    }
}
