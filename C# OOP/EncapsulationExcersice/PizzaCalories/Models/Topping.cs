using System;
using PizzaCalories.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
     public class Topping
    {
        private const double baseCaloriesPerGram = 2;
        private const double meatIndex = 1.2;
        private const double veggiesIndex = 0.8;
        private const double cheeseIndex = 1.1;
        private const double sauseIndex = 0.9;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!IsValidTopping(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingType, value));
                }
                this.type = value;
            }
        }

        private bool IsValidTopping(string value)
        {
            if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce" )
            {
                return true;
            }
            return false;
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value >50)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidtoppingWeight, this.Type));
                }
                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double totaLcalories = 0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    totaLcalories = CaloriesPerGram() * meatIndex;
                    break;
                case "veggies":
                    totaLcalories = CaloriesPerGram() * veggiesIndex;
                    break;
                case "cheese":
                    totaLcalories = CaloriesPerGram() * cheeseIndex;
                    break;
                case "sauce":
                    totaLcalories = CaloriesPerGram() * sauseIndex;
                    break;
                default:
                    break;
            }

            return totaLcalories;
        }

        private double CaloriesPerGram()
        {
            double caloriesPerGram = baseCaloriesPerGram * this.Weight;
            return caloriesPerGram;
        }

    }
}
