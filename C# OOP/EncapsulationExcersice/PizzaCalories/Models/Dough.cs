using System;
using PizzaCalories.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int defaultCaloriescaloriesPerGram = 2;

        private const double whiteDoughCalories = 1.5;
        private const double wholegrainDoughCalories = 1.00;
        private const double chewyDoughCalories = 1.1;
        private const double crispyDouighCalories = 0.9;
        private const double homemadeDoughCalories = 1.00;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (!IsValidType(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughType);
                }
                this.flourType = value;
            }
        }

        private bool IsValidType(string type)
        {
            if (type.ToLower() == "white" || type.ToLower() == "wholegrain")
            {
                return true;
            }
            return false;
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!IsValidTechnique(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughType);
                }
                this.bakingTechnique = value;
            }
        }

        private bool IsValidTechnique(string type)
        {
            if (type.ToLower() == "crispy" 
                ||type.ToLower() == "chewy"
                || type.ToLower() == "homemade")
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
                if (value < 1 || value >200)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWeight);
                }
                this.weight = value;
            }
        }


        public double DoughCalories()
        {
            double totalCaloriesFlourType = 0;

            switch (this.FlourType.ToLower())
            {
                case "white":
                    totalCaloriesFlourType = CaloriesPerGram() * whiteDoughCalories;
                    break;
                case "wholegrain":
                    totalCaloriesFlourType = CaloriesPerGram() * wholegrainDoughCalories;
                    break;
                default:
                    break;
            }

            double totalCalories = 0;

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    totalCalories = totalCaloriesFlourType * crispyDouighCalories;
                    break;
                case "chewy":
                    totalCalories = totalCaloriesFlourType * chewyDoughCalories;
                    break;
                case "homemade":
                    totalCalories = totalCaloriesFlourType * homemadeDoughCalories;
                    break;
                default:
                    break;
            }

            return totalCalories;
        }

        private double CaloriesPerGram()
        {
            double result = defaultCaloriescaloriesPerGram * this.Weight;
            return result;
        }
    }
}
