using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var countOfHeroes = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < countOfHeroes; i++)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = CreateHeros.CreateHero(heroName, heroType);
                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    i--;
                    Console.WriteLine(e.Message);
                }
            }

            var bossesPower = int.Parse(Console.ReadLine());

            var heroesPower = heroes.Select(h => h.Power).Sum();

            foreach (var hero in heroes)
            {
                string castAbility = hero.CastAbility();
                Console.WriteLine(castAbility);
            }

            if (bossesPower <= heroesPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
