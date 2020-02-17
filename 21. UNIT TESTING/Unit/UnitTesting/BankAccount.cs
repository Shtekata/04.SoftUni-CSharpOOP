using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class BankAccount
    {
        private decimal balance;
        public BankAccount(decimal balance)
        {
            Balance = balance;
        }
        public decimal Balance
        {
            get => balance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can not be negative!");
                }

                balance = value;
            }
        }

        public void Deposit(decimal sum)
        {
            if(sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number!");
            }

            Balance += sum;
        }

        public decimal Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum must be positive number!");
            }

            Balance -= sum;

            return Balance;
        }


    }
}
