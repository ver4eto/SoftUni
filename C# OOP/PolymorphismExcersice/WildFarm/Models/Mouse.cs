using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight,  string livingReagion) 
            : base(name, weight,  livingReagion)
        {
        }

        protected override List<Type> foodsEaten => new List<Type> { typeof (Vegetable), typeof(Fruit)};

        protected override double FoodMultiplier => 0.10;

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
