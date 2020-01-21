using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
           
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
            this.CodeNumber = codeNumber;
        }
        public int CodeNumber { get; }

        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();
                       
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
