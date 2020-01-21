using System;
using System.Collections.Generic;
using PizzaCalories.Exceptions;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            toppings = new List<Topping>();
        }

        public  void AddTopping(Topping topping)
        {
            if (toppings.Count==10)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfToppings);
            }
            toppings.Add(topping);
        }
        public Dough Dough
        {
            get => this.dough;
            set => this.dough = value;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (!IsValidName(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaName);
                }
                this.name = value;
            }
        }

        public double TotalCalories()
        {
            double toppingsCalories = 0;

            foreach (Topping topping in toppings)
            {
                toppingsCalories += topping.TotalCalories();
            }
            double totalCaloriesPizza = this.dough.DoughCalories() + toppingsCalories;

            return totalCaloriesPizza;
        }

        private bool IsValidName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length >15)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder pizza = new StringBuilder();

            pizza.Append($"{this.Name} - {this.TotalCalories():f2} Calories.");

            return pizza.ToString().TrimEnd();

        }
    }
}
