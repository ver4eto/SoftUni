using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private readonly IList<string> items;

        //protected Planet()
        //{
        //}
        public Planet(string name)
            //:this()
        {
            this.Name = name;
            this.items = new List<string>().AsReadOnly();


        }
        public ICollection<string> Items => this.items;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(Utilities.Messages.ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        //public void AddItems(string[] planetItems)
        //{
        //    foreach (var item in planetItems)
        //    {
        //        this.items.Add(item);
        //    }
        //}

        //public void RemoveItem(string item)
        //{
        //    this.items.Remove(item);
        //}
    }
}
