using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Exceptions
{
  public  class ExceptionMessages
    {
        public static string InvalidDoughType = "Invalid type of dough.";

        public static string InvalidWeight = "Dough weight should be in the range [1..200].";

        public static string InvalidToppingType = "Cannot place {0} on top of your pizza.";

        public static string InvalidtoppingWeight = "{0} weight should be in the range [1..50].";

        public static string InvalidPizzaName = "Pizza name should be between 1 and 15 symbols.";

        public static string InvalidNumberOfToppings = "Number of toppings should be in range [0..10].";
    }
}
