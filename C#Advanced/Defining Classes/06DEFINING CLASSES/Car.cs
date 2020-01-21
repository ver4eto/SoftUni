﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06DEFINING_CLASSES
{
    class Car
    {
        private int year;
        private string make;
        private double fuel;

        public double FuelConsumption { get; set; }


        public double Fuel
        {
            get
            {
                return Math.Floor(fuel);
            }
            set
            {
                if (value > 1)
                {
                    fuel += value;
                }
            }
        }


        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                this.make = value;
            }
        }

        public string Model { get; set; }

        public int Year
        {
            get
            {
                if (year < 5)
                {
                    return year;
                }
                return year - 3;
            }
        }

        public Car()
        {
            year = 1;
            fuel = 10;
            FuelConsumption = 8;
        }

        public Car(int years)
        {
            this.year = years;
            fuel = 10;
            FuelConsumption = 8;
        }

        public int RealAge()
        {
            return year;
        }

        public void Drive(double distance)
        {
            double consumedFuel = distance / 100 * FuelConsumption;
            if (consumedFuel>fuel)
            {
                throw new ArgumentException("Go to gas statiom");
            }

            fuel -= consumedFuel;
        }
    }
}
