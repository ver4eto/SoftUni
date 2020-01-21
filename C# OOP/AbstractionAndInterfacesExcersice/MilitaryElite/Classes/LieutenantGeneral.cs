using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;
namespace MilitaryElite.Classes
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<IPrivate> privates )
            :base(id, firstName,lastName, salary)
        {
           this.Privates = privates;
        }
        public List<IPrivate> Privates { get; set ; }

        public override string ToString()
        {
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var person in Privates)
            {
                sb.AppendLine($"  {person.ToString()}");
            }

            return sb.ToString().TrimEnd();

        }
      
    }
}
