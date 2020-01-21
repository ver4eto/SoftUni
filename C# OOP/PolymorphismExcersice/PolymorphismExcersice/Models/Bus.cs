using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
  public  class Bus : Vehicle
    {
        private  double AIR_CONDITION_CONSUMPTION;
        public Bus(double fuelQuantity, double fuelConsuption, double tankCapacity)
            : base(fuelQuantity, fuelConsuption, tankCapacity)
        {
            //this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        }

        public string TypeOfBus { get; /*private*/ set; }

        public override void Drive(double distance)
        {
            if (this.TypeOfBus=="empty")
            {
                AIR_CONDITION_CONSUMPTION = 0;
            }
            else
            {
                AIR_CONDITION_CONSUMPTION = 1.4;
            }
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
            base.FuelQuantity += refuelAmount;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
