namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks.Entities;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Foods.Entities;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using SoftUniRestaurant.Models.Tables.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
       

        public string AddFood(string type, string name, decimal price)
        {
            
            IFood food ;
            if (type=="Dessert")
            {
                food = new Dessert(name, price);
            }
            else if (type=="Soup")
            {
                food = new Soup(name, price);
            }
            else if (type=="Salad")
            {
                food = new Salad(name, price);
            }
            else 
            {
                food = new MainCourse(name, price);
            }
            menu.Add(food);
           
            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:f2} to the pool";

        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink;
            if (type=="Alcohol")
            {
                drink = new Alcohol(name, servingSize, brand);
            }
            else if (type=="FuzzyDrink")
            {
                drink = new FuzzyDrink(name, servingSize, brand);
            }
            else if (type=="Water")
            {
                drink = new Water(name, servingSize, brand);
            }
            else
            {
                drink = new Juice(name, servingSize, brand);
            }
            drinks.Add(drink);
          
            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;
            if (type=="Inside")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tables.Add(table);
            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {            
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table==null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                //totalIncome += table.NumberOfPeople * table.PricePerPerson;
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IFood food = menu.FirstOrDefault(f => f.Name == foodName);

            if (table==null)
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (food==null)
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                table.OrderFood(food);
                //totalIncome += food.Price;
                return $"Table {table.TableNumber} ordered {food.Name}";
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand==drinkBrand);

            if (table==null)
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (drink==null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                table.OrderDrink(drink);
                //totalIncome += drink.Price;
                return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
            }
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

           string result= $"Table: {tableNumber}{Environment.NewLine}Bill: {table.GetBill():f2}";
            totalIncome += table.GetBill();

            table.Clear();
            return result;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in tables.Where(t=>t.IsReserved==false))
            {
               sb.AppendLine( table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in tables.Where(t => t.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            decimal allIncome = totalIncome;

            //foreach (ITable table  in tables)
            //{
            //    allIncome += table.GetBill();
            //}

            return $"Total income: {allIncome:f2}lv";


        }
    }
}
