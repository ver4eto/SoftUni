using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        string IPerson.Name { get;set; }

        string IResident.Name { get; set; }

        int IPerson.Age { get;}

        string IResident.Country { get;}

        void IPerson.GetName()
        {
            Console.WriteLine(this.Name);
        }

        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }
    }
}
