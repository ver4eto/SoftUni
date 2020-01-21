using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingReagion, string breed)
            : base(name, weight,  livingReagion, breed)
        {
        }

        protected override double FoodMultiplier => 0.30;

        protected override List<Type> foodsEaten => new List<Type> { typeof(Vegetable), typeof(Meat) };

        public override string AskForFood()
        {
           return "Meow";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
