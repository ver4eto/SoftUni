using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Exceptions;

namespace Vehicles
{
   public class Truck : Vehicle
    {
        private double AIR_CONDITION_CONSUMPTION = 1.6;
        private double TANK_CAPACITY = 0.95;
        public Truck(double fuelQuantity, double fuelConsuption,double tankCapacity)
            :base (fuelQuantity, fuelConsuption,tankCapacity)
        {
            //this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        }

        public override void Drive(double distance)
        {
            double totalNeededFuelForDistance = distance * (base.FuelConsumption + AIR_CONDITION_CONSUMPTION);

            if (totalNeededFuelForDistance <= base.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                base.FuelQuantity -= totalNeededFuelForDistance;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public override void Refuel(double refuelAmount)
        {
            if (refuelAmount <= 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeNumberOfFuel);
            }
            if (base.FuelQuantity + refuelAmount > base.TankCapcity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.FuelMoreThanTankCapacity, refuelAmount));
            }
            base.FuelQuantity += refuelAmount * TANK_CAPACITY;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
