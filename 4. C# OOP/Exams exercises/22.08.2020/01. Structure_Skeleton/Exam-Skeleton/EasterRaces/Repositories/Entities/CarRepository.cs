using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<Car>
    {
        private readonly ICollection<ICar> cars;
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

    }
}
