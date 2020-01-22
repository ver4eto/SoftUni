using Logger.Contracts;
using Logger.Enumerations;
using Logger.Errors;
using Logger.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string dataFormat = "M/dd/yyyy h:mm:ss tt";
        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString,dataFormat , CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new InvalidDateFormatExc();                
            }

            return new Error(dateTime, message, level);
        }
    }
}
