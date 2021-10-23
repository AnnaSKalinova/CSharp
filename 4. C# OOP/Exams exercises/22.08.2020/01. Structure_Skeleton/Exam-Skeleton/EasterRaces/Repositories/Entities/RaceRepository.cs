using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<Race>
    {
        private readonly ICollection<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
    }
}
