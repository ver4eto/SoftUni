using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Entities
{
    public class InsideTable : Table, ITable
    {
        private const decimal INITIAL_PRICE_PER_PERSON = 2.50m;
        public InsideTable(int tableNumber, int capacity/*, decimal pricePerPerson*/) 
            : base(tableNumber, capacity, INITIAL_PRICE_PER_PERSON)
        {
           // this.PricePerPerson = INITIAL_PRICE_PER_PERSON;
        }
    }
}
