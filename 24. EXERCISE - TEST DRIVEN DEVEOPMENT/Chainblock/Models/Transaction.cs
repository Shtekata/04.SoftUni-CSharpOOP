using Chainblock.Contracts;
using System;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus transactionStatus;
        private string from;
        private string to;
        private double amount;
        public Transaction(int id, TransactionStatus ts, string from, string to, double amount)
        {
            Id = id;
            Status = ts;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id should be positive!");
                }
                id = value;
            }
        }
        public TransactionStatus Status
        {
            get => transactionStatus;
            set => transactionStatus = value;
        }
        public string From
        {
            get => from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name should not be whitespace or empty!");
                }

                from = value;
            }
        }
        public string To
        {
            get => to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Receiver name should not be whitespace or empty!");
                }

                to = value;
            }
        }
        public double Amount
        {
            get => amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount value must be positive!");
                }

                amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            throw new System.NotImplementedException();
        }
    }
}
