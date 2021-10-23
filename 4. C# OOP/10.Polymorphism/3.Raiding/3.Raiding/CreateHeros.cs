using System;

namespace Raiding
{
    public class CreateHeros
    {
        public static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero = null;

            switch (heroType)
            {
                case "Druid":
                    hero = new Druid(heroName);
                    break;
                case "Paladin":
                    hero = new Paladin(heroName);
                    break;
                case "Rogue":
                    hero = new Rogue(heroName);
                    break;
                case "Warrior":
                    hero = new Warrior(heroName);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}

