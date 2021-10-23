using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetAll().Any(dr => dr.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            Driver driver = new Driver(driverName);
            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetAll().Any(c => c.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            Car car = null;

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }

            cars.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!drivers.GetAll().Any(dr => dr.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (!cars.GetAll().Any(c => c.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            Driver driver = drivers.GetAll().FirstOrDefault(dr => dr.Name == driverName);
            Car car = cars.GetAll().FirstOrDefault(c => c.Model == carModel);
            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (!drivers.GetAll().Any(dr => dr.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            Driver driver = drivers.GetAll().FirstOrDefault(dr => dr.Name == driverName);
            Race race = races.GetAll().FirstOrDefault(r => r.Name == raceName);
            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }


        public string CreateRace(string name, int laps)
        {
            if (races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            Race race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (!races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            Race race = races.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            StringBuilder sb = new StringBuilder();
            var counter = 1;

            foreach (var driver in drivers.GetAll().OrderByDescending(dr => dr.Car.CalculateRacePoints(race.Laps)))
            {
                if (counter == 4)
                {
                    break;
                }
                if (counter == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driver.Name, race.Name));
                    driver.WinRace();
                }
                if (counter == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driver.Name, race.Name));
                }
                if (counter == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, driver.Name, race.Name));
                }

                counter++;
            }

            this.races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
