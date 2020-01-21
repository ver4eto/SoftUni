using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Repair : IRepair
    {

        public Repair(string partName, int hooursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hooursWorked;
        }
        public string PartName { get; }

        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
