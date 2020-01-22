using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.riders = new List<IRider>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,value,5));
                }
                this.name = value;
            }
        }


        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = 1;
            }
        }

        public IReadOnlyCollection<IRider> Riders
        {
            get
            {
                return this.riders.AsReadOnly();
            }
            private set
            {
                this.riders = value.ToList();
            }
        }

        public void AddRider(IRider rider)
        {
            if (rider==null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderInvalid));
            }
            else if (rider.CanParticipate==false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate,rider.Name));
            }
            else if (this.riders.Contains(rider))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded,rider.Name,this.Name));
            }
            this.riders.Add(rider);
        }
    }
}
