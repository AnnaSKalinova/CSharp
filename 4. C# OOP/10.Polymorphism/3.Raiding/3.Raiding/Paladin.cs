﻿namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
