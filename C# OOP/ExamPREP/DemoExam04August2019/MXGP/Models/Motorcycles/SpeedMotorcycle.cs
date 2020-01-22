using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MIN_HORSE_POWER = 50;
        private const int MAX_HORSE_POWER = 69;

        private const double CUBIC_CENTIMETER = 125;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETER)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value <MIN_HORSE_POWER || value >MAX_HORSE_POWER)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                base.HorsePower = value;
            }
             
        }
    }
}
