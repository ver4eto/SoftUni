using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight,  double wingSize) 
            : base(name, weight,wingSize)
        {
            
        }

        protected override List<Type> foodsEaten => new List<Type> { typeof(Seeds), typeof(Meat), typeof(Vegetable), typeof(Fruit) };

        protected override double FoodMultiplier => 0.35;

        public override string AskForFood()
        {
            return "Cluck";
        }

        
        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
