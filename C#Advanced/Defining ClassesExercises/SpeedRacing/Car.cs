﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public Car(string model,
            double fuelAMount,
            double fuelConsumption 
           )
        {
            Model = model;
            FuelAmount = fuelAMount;
            FuelConsumptionPerKilometer = fuelConsumption;

            TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance {get;set;}

        public void Drive(double amountOfKm)
        {
            double requiredFuel = amountOfKm * FuelConsumptionPerKilometer;
            if (requiredFuel <= FuelAmount)
            {
                TravelledDistance += amountOfKm;
                FuelAmount -= requiredFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }



    }
}
