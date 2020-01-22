﻿using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Entities
{
    public class Soup : Food, IFood
    {
        private const int InitialServingSize = 245;
        public Soup(string name, /*int servingSize,*/ decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
