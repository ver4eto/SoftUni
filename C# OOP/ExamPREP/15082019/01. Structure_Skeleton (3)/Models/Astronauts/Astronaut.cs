using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack bag;
        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(Utilities.Messages.ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
          protected   set
            {
                if (value<0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath
        {
            get
            {
                if (this.Oxygen>0)
                {
                    return true;
                }
                return false;
            }
        }

        public IBag Bag 
        {
            get
            {
                return this.bag;
            }
        }

        public virtual void Breath()
        {
            if (this.Oxygen-10>=0)
            {
                this.Oxygen -= 10;
            }
        }
    }
}
