using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Car
    {
        public string Model { get; set; }
        public Tire[] Tires { get; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }

        public Car(string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType,
           params Tire[] tires)
        {
            Model = model;

            Tires = tires;

            Cargo = new Cargo(cargoWeight, cargoType);

            Engine = new Engine(engineSpeed, enginePower);

        }
    }
  
}

