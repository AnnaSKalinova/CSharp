using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;
        private string owner;
        private bool isBought;
        private bool isChipped;
        private bool isChecked;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }
        public string Name { get; set; }
        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner 
        {
            get => "Service";
            set => this.owner = value;
        }
        public bool IsBought
        {
            get => false;
            set => this.isBought = value;
        }
        public bool IsChipped
        {
            get => false;
            set => this.isChipped = value;
        }
        public bool IsChecked
        {
            get => false;
            set => this.isChecked = value;
        }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
