using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Entities
{
   public class Alcohol: Drink, IDrink
    {
        private const decimal ALCOHOL_PRICE = 3.50m;

        public Alcohol(string name, int servingSize,/* decimal price,*/ string brand)
            : base(name, servingSize, ALCOHOL_PRICE, brand)
        {
        }
    }
}
