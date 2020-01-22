using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Entities
{
    public class Salad : Food, IFood
    {
        private const int InitialServingSize = 300;
        public Salad(string name, /*int servingSize,*/ decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
