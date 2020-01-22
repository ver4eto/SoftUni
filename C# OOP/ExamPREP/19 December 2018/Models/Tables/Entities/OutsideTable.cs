using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Entities
{
    public class OutsideTable : Table, ITable
    {
        private const decimal INITIAL_PRICE_PER_PERSON = 3.50m;
        public OutsideTable(int tableNumber, int capacity/*, decimal pricePerPerson*/) 
            : base(tableNumber, capacity, INITIAL_PRICE_PER_PERSON)
        {
           // this.PricePerPerson = INITIAL_PRICE_PER_PERSON;
        }
    }
}
