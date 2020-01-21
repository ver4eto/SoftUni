using System;
using System.Collections.Generic;
using ShoppingSpree.Exceptions;

using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;

            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                this.name = value;
            }
        }

        public double Money
        {
            get => this.money;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeNumberForMoneyException);
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {            
            if (CanAffordProduct(product))
            {               
                    products.Add(product);
                    this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
                
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Name} - ");
            if (products.Count>0)
            {
                foreach (Product product in products)
                {
                    result.Append($"{product.ToString()}, ");
                }

                //result.AppendLine($"{string.Join(", ",products.ToString())}");
            }
            else
            {
                result.AppendLine("Nothing bought");
            }

            return result.ToString().TrimEnd(new char [] {',', ' '});
        }
        private bool CanAffordProduct(Product product)
        {
            if (this.Money > product.Cost)
            {
                return true;
            }
            return false;
        }
    }
}
