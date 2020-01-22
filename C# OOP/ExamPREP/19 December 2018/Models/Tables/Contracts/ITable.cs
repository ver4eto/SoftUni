using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Drinks.Entities;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.Entities;
using System.Collections.Generic;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        int Capacity { get; }
        int TableNumber { get; }

        //List<IFood> FoodOrders { get; }
        //List<IDrink> DrinkOrders { get; }
        int NumberOfPeople { get; }
        decimal PricePerPerson { get; }
        bool IsReserved { get;   }
        decimal Price { get; }

        void Reserve(int numberOfPeople);
      void  OrderFood(IFood food);
        void OrderDrink(IDrink drink);
        decimal GetBill();
        void Clear();
        string GetFreeTableInfo();
        string GetOccupiedTableInfo();

    }
}
