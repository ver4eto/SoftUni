using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food, IFood
    {
        private const int InitialServingSize = 200;
        public Dessert(string name, /*int servingSize,*/ decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
