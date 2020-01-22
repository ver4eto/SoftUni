using MXGP.Core.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders.Entities;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RaceRepository races=new RaceRepository();
        private RiderRepository riders = new RiderRepository();
        private MotorcycleRepository motors = new MotorcycleRepository();


        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riders.GetByName(riderName);
            IMotorcycle motorcycle = this.motors.GetByName(motorcycleModel);

            if (rider==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound,riderName));
            }
            else if (motorcycle==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound,motorcycleModel));
            }
            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded,rider.Name, motorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.races.GetByName(raceName);
            IRider rider = this.riders.GetByName(riderName);

            if (race==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,raceName));
            }
            else if (rider==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound,riderName));
            }
            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded,rider.Name, race.Name);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = this.motors.GetByName(model);

            if (motorcycle==null)
            {
                if (type== "Speed")
                {
                    /*SpeedMotorcycle speedMotorcycle*/motorcycle = new SpeedMotorcycle(model, horsePower);
                   
                }
                else
                {
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    
                }
                this.motors.Add(motorcycle);
                return string.Format(OutputMessages.MotorcycleCreated,motorcycle.GetType().Name,motorcycle.Model);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleExists,motorcycle.Model);
            }
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.races.GetByName(name);

            if (race==null)
            {
                race = new Race(name, laps);
                this.races.Add(race);
                return string.Format(OutputMessages.RaceCreated,race.Name);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists,race.Name));
            }
        }

        public string CreateRider(string riderName)
        {
            IRider rider = this.riders.GetByName(riderName);
            if (rider==null)
            {
                rider = new Rider(riderName);
                this.riders.Add(rider);
                return string.Format(OutputMessages.RiderCreated, rider.Name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists,rider.Name));
            }
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,raceName));
            }
            else if (race.Riders.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,race.Name, 3));
            }

            List<IRider> winners = new List<IRider>();

            foreach (IRider rider in race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3))
            {
                winners.Add(rider);
            }

            StringBuilder sb = new StringBuilder();

            IRider first = winners[0];
            IRider second = winners[1];
            IRider third = winners[2];

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition,first.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, second.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, third.Name, race.Name));

            this.races.Remove(race);

            return sb.ToString().TrimEnd();

        }

        public void End()
        {
            Environment.Exit(0);
        }
    }
}
