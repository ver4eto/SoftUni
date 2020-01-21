using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Cargo
    {
        //cargoWeight} {cargoType

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int weight, string type)
        {
            CargoWeight = weight;
            CargoType = type;
        }
    }
}
