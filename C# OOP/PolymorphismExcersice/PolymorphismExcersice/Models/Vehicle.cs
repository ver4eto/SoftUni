using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Exceptions;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsuption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
              this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            //this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;

            //this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsuption;
            this.TankCapcity = tankCapacity;

           
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; private set; }
        public double TankCapcity { get; private set; }
        public abstract void Drive(double distance);


        public abstract void Refuel(double refuelAmount);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
