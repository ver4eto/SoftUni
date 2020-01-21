using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Tire
    {
        public int Age { get; set; }
        public double TirePressure { get; set; }

        public Tire(int age, double pressure)
        {
            Age = age;
            TirePressure = pressure;
        }
    }
}
