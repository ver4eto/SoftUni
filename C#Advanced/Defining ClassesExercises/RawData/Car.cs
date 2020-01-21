using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawData
{
    class Car
    {
        private List<Tire> tires;
        

        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public string Model { get; set; }
        public List<Tire> Tires { get; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            tires = new List<Tire>() { };
            Tire tireOne = new Tire(tire1Pressure, tire1Age);
            Tire tireTwo = new Tire(tire2Pressure, tire2Age);
            Tire tireThree = new Tire(tire3Pressure, tire3Age);
            Tire tireFour = new Tire(tire4Pressure, tire4Age);
            Tires = tires;

            tires.Add(tireOne);
            tires.Add(tireTwo);
            tires.Add(tireThree);
            tires.Add(tireFour);
        }

        public void PressureIsBelow1(Car car)
        {
            //if (car.Tires.Contains())
            //{

            //}
        }
    }
}
