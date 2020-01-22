using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class FuzzyDrink : Drink, IDrink
    {
        private const decimal FUZZY_DRINK_PRICE = 2.50m;
        public FuzzyDrink(string name, int servingSize, /*decimal price,*/ string brand) 
            : base(name, servingSize, FUZZY_DRINK_PRICE, brand)
        {
        }
    }
}
