using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
   public abstract class Feline : Mammal
    {
       
        public Feline(string name, double weight, /*int foodEaten,*/ string livingReagion,string breed)
            : base(name, weight, /*foodEaten,*/ livingReagion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }
    }
}
