using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corp,List<IRepair>repairs)
            :base(id, firstName, lastName, salary, corp)
        {
            this.repairs = repairs;
        }
        public List<IRepair> repairs { get; }

        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();

           
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Repairs:");
            foreach (var repair in this.repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
