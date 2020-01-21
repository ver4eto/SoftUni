using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public abstract class Soldier : ISoldier
    {
        //public Soldier(int id, string firstName, string lastName)
        //{
        //    this.ID = id;
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //}
      
        public string FirstName { get; set ; }
        public string LastName { get ; set ; }
        public int ID { get ; set ; }
    }
}
