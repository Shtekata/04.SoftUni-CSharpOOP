﻿using System;
using ShoppingSpree.Exception;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
                }

                name = value;
            }
        }
        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }
                cost = value;
            }

        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
