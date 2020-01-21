using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public class Owl : Bird
    {


        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> foodsEaten => new List<Type> { typeof(Meat) };

        protected override double FoodMultiplier => 0.25;

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}
