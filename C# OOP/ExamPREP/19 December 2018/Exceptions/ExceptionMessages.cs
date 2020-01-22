using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Exceptions
{
   public class ExceptionMessages
    {
        public const string NameIsNullOrWhitespaceException = "Name cannot be null or white space!";

        public const string ServingSizeLessOrEqualToZeroException = "Serving size cannot be less or equal to zero";

        public const string PriceLessOrEqualTozero = "Price cannot be less or equal to zero!";

        public const string BrandIsNullOrWhtespaceException = "Brand cannot be null or white space!";

        public const string CapacityIsLessThanZeroException = "Capacity has to be greater than 0";

        public const string PeopleCannotBeLessThanZero = "Cannot place zero or less people!";
    }
}
