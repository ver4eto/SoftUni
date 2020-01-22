using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Exceptions
{
    public class InvalidDateFormatExc : Exception
    {
        private const string EXC_MESSAGE = "Invalid DateTime Format!";

        public InvalidDateFormatExc()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidDateFormatExc(string message) 
            : base(message)
        {
        }

        public InvalidDateFormatExc(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
