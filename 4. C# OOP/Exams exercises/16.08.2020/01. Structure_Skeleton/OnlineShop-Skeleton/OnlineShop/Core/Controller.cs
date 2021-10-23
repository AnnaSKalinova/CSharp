using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;
            switch (computerType)
            {
                case "DesktopComputer":
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case "Laptop":
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            ComputerType computerTypeEnum;
            if (!Enum.TryParse(computerType, out computerTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            ComponentType componentTypeEnum;
            if (!Enum.TryParse(componentType, out componentTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            CheckIfCompExists(computerId);

            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }


        public string RemoveComponent(string componentType, int computerId)
        {
            IComponent component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            CheckIfCompExists(computerId);

            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);

            this.components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, computerId);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case "HeadSet":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            CheckIfCompExists(computerId);

            if (peripherals.Any(p => p.Id == id))
            {
                throw new AggregateException(ExceptionMessages.ExistingPeripheralId);
            }

            PeripheralType peripheralTypeEnum;
            if (!Enum.TryParse(peripheralType, out peripheralTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            this.peripherals.Add(peripheral);
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral peripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            CheckIfCompExists(computerId);
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);

            this.peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string BuyComputer(int id)
        {
            CheckIfCompExists(id);

            IComputer computer = computers.FirstOrDefault(c => c.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers.OrderByDescending(c => c.OverallPerformance).FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfCompExists(id);

            IComputer computer = computers.FirstOrDefault(c => c.Id == id);

            return computer.ToString();
        }

        private void CheckIfCompExists(int computerId)
        {
            if (!computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
