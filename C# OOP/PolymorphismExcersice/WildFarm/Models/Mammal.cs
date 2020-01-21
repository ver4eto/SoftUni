using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
   public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, /*int foodEaten,*/ string livingReagion)
            :base(name, weight)
        {
            this.LivingRegion = livingReagion;
        }
        public string LivingRegion { get; set; }
    }
}
