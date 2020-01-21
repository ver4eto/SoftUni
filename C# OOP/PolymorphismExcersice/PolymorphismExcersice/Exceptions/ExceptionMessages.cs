using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Exceptions
{
    public class ExceptionMessages
    {
        public const string NegativeNumberOfFuel= "Fuel must be a positive number";

        public const string FuelMoreThanTankCapacity = "Cannot fit {0} fuel in the tank";
    }
}
