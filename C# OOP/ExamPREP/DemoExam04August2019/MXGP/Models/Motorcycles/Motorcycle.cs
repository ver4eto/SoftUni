using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;
    
        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<4)
                {
                    int lenght = 4;
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value,lenght));
                }
                this.model = value;
            }
        }

        public virtual int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value<50 || value>100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }
        

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
