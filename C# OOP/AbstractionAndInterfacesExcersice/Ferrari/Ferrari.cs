using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {

        private string model = "488-Spider";

        public Ferrari(string name)
        {
            this.DriverName = name;
        }
        public string DriverName { get; private set; }

        public string PushGas()
        {
           return "Gas!";
        }

        public string UseBreaks()
        {
           return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.model}/{this.UseBreaks()}/{this.PushGas()}/{this.DriverName}";
        }
    }
}
