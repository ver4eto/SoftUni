using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corp, List<IMission> missions)
            :base (id, firstName, lastName, salary, corp)
        {
            this.missions = missions;
        }
        public List<IMission> missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
       

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Missions:");
            foreach (var mission in this.missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
