using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingReagion)
            : base(name, weight, livingReagion)
        {
        }

        protected override List<Type> foodsEaten => new List<Type> { typeof(Meat) };

        protected override double FoodMultiplier => 0.4;

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
