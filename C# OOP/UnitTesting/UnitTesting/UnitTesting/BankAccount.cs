using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
   public class BankAccount
    {
        private decimal balance;

        public decimal Balance
        {
            get => this.balance;
            
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Balance cannot be negative!");
                }
                this.balance = value;
            }
        }

        public BankAccount(decimal balance)
        {
            this.Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount<=0)
            {
                throw new ArgumentException("Amount cannot be zero or less!");
            }

            this.Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount<=0)
            {
                throw new ArgumentException("Withdrawn amount cannot be zero or less!");
            }

          
         return  this.Balance -= amount;
        }
    }
}
