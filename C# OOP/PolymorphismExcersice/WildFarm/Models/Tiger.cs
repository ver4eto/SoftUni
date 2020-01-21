using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight,  string livingReagion, string breed)
            : base(name, weight,  livingReagion, breed)
        {
        }

        protected override List<Type> foodsEaten => new List<Type> {typeof(Meat) };

        protected override double FoodMultiplier => 1.0;

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
