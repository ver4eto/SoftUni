using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Models.Foods;

namespace WildFarm.Models
{
   public abstract class Animal : IAnimal
    {

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            //foodsEaten = new List<Type>();
        }

        protected abstract List<Type> foodsEaten { get; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected abstract double FoodMultiplier { get; }
        public abstract string AskForFood();

        public void Feed(Food food)
        {
            if (!foodsEaten.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFoodType,this.GetType().Name,food.GetType().Name));
            }

            this.Weight += food.Quantity * this.FoodMultiplier;
            FoodEaten += food.Quantity;
            
        }

        
    }
}
