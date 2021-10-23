using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<Driver>
    {
        private readonly ICollection<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
    }
}
