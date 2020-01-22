using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Juice : Drink, IDrink
    {
        private const decimal JUICE_PRICE = 1.80m;
        public Juice(string name, int servingSize, /*decimal price, */string brand)
            : base(name, servingSize, JUICE_PRICE, brand)
        {
        }
    }
}
