using System;

namespace Raiding
{
    public abstract class BaseHero
    {
        private string type;
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public virtual int Power { get; }
        public string Type
        {
            get => this.type;
            private set
            {
                if (value != "Druid" && value != "Paladin" && value != "Rogue" && value != "Warrior")
                {
                    throw new ArgumentException("Invalid hero!");
                }
                this.type = value;
            }
        }

        public abstract string CastAbility();
    }
}
