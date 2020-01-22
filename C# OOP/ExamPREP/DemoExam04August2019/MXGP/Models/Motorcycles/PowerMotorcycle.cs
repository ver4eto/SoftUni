using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int MIN_HORSE_POWER = 70;
        private const int MAX_HORSE_POWER = 100;

        private const double CUBIC_CENTIMETER = 450;
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETER)
        {
        }

        public override int HorsePower
        {
            get
            {
                return base.HorsePower;
            }
            protected set
            {
                if (value < MIN_HORSE_POWER || value > MAX_HORSE_POWER)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                base.HorsePower=value;
            }
        } 
    }
}
