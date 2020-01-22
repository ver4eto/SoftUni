using SoftUniRestaurant.Exceptions;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Entities
{
    public abstract class Table : ITable        
    {
        private int capacity;
        private int tableNumber;
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int numberOfPeople;
        //private decimal pricePerPerson;
        private bool isReserved;
             

        private Table()
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
            :this()
        {
            this.Capacity = capacity;
            this.TableNumber = tableNumber;
            this.PricePerPerson = pricePerPerson;
        }

      
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityIsLessThanZeroException);
                }
                this.capacity = value;
            }
        }

        public int TableNumber
        {
            get => this.tableNumber;
            private set
            {
                this.tableNumber = value;
            }
        }

      
        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.PeopleCannotBeLessThanZero);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get; set;
            //get => this.pricePerPerson;
            //private set
            //{
            //    if (value <= 0m)
            //    {
            //        throw new ArgumentException(ExceptionMessages.PriceLessOrEqualTozero);
            //    }
            //    this.pricePerPerson = value;

            //}
        }

        public bool IsReserved
        {
            get => this.isReserved;
            private set
            {
                if (this.NumberOfPeople<1)
                {
                    value= false;
                }
                else
                {
                    value = true;
                }                

                this.isReserved = value;
            }
        }
        
       

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        private List<IFood> FoodOrders => this.foodOrders;

        private List<IDrink> DrinkOrders => this.drinkOrders;

        public void Reserve(int numberOfPeople)
        {            
            this.NumberOfPeople = numberOfPeople;
            IsReserved=true;
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal totalBill=0m /*= this.PricePerPerson*this.NumberOfPeople*/;
            foreach (IFood food in this.FoodOrders)
            {
                totalBill += food.Price;
            }

            foreach (IDrink drink in this.DrinkOrders)
            {
                totalBill += drink.Price;
            }
            return totalBill;
        }

        public void Clear()
        {
            this.DrinkOrders.Clear();
            this.FoodOrders.Clear();
            this.NumberOfPeople = 0;
            this.IsReserved = false;
           
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            sb.Append("Food orders: ");
            if (this.FoodOrders.Count==0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine($"{this.FoodOrders.Count}");
                foreach (var item in this.FoodOrders)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }
            sb.Append("Drink orders: ");
            if (this.DrinkOrders.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine($"{this.DrinkOrders.Count}");
                foreach (var item in this.DrinkOrders)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }
            return sb.ToString().TrimEnd();
        }

    }
}
