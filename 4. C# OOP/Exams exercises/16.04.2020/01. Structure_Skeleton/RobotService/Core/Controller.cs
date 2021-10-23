using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Core
{
    class Controller : IController
    {
        private readonly IGarage garage;
        public Controller()
        {
            this.garage = new Garage();
        }
        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (robotType != "HouseholdRobot" && robotType != "WalkerRobot" && robotType != "PetRobot")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            if (garage.Robots.Any(r => r.Key == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, name));
            }

            IRobot robot = null;

            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
            }

            garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }
        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = this.garage.Robots[robotName];
            
        }
        public string Charge(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }


        public string History(string procedureType)
        {
            throw new System.NotImplementedException();
        }


        public string Polish(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Rest(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Sell(string robotName, string ownerName)
        {
            throw new System.NotImplementedException();
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Work(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
