using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName,decimal salary )
           
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }
        public decimal Salary { get ; set ; }
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public override string ToString()
        {          

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");

            return sb.ToString().TrimEnd();
        }
        
    }
}
