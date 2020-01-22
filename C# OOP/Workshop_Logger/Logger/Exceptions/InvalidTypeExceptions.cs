using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Exceptions
{
  public  class InvalidTypeExceptions : Exception
    {

        private const string EXC_MESSAGE = "Invalid Layout Type!";
        public InvalidTypeExceptions()
            :base (EXC_MESSAGE)
        {

        }

        public InvalidTypeExceptions(string message)
            : base (message)
        {

        }
    }
}
