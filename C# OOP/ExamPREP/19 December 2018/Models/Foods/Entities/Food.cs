using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using SoftUniRestaurant.Exceptions;


namespace SoftUniRestaurant.Models.Foods.Entities
{
    public abstract  class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }
       
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameIsNullOrWhitespaceException);
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value<=0m)
                {
                    throw new ArgumentException(ExceptionMessages.PriceLessOrEqualTozero);
                }
                this.price = value;
            }
        }

        public int ServingSize
        {
            get => this.servingSize;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.ServingSizeLessOrEqualToZeroException);
                }
                this.servingSize = value;
            }
        }
               

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
