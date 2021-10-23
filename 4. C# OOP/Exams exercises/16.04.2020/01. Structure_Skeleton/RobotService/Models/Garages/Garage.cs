using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int capacity = 10;
        private readonly Dictionary<string, IRobot> robots;
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (robots.Count > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (robots.Any(r => r.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot), robotName);
            }
            var robot = robots.FirstOrDefault(r => r.Key == robotName).Value;

            robots.Remove(robotName, out robot);
            robot.IsBought = true;
            robot.Owner = ownerName;
        }
    }
}
