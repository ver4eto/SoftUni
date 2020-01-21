using System;
using Telephony.Exceptions;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Browsing(string adressForBrowsing)
        {
            bool isDigit = false;
            foreach (char item in adressForBrowsing)
            {
                if (char.IsDigit(item))
                {
                    isDigit = true;
                    break;
                }
               
            }

            if (isDigit)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidURL);
            }
            Console.WriteLine($"Browsing: {adressForBrowsing}!");
        }

        public void CallingOtherPhones(string number)
        {
            bool isDifferentThanDigit = false;
            foreach (char item in number)
            {
                if (!char.IsDigit(item))
                {
                    isDifferentThanDigit = true;
                    break;
                }

            }

            if (isDifferentThanDigit)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumber);
            }
            Console.WriteLine($"Calling... {number}");
        }
    }
}
