using System;
using System.Collections.Generic;
using ShoppingSpree.Exception;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;
        public Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            Name = name;
            Money = money;
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }
                money = value;
            }
        }
        public void AddProduct(Product product)
        {
            var moneyLeft = money - product.Cost;

            if (moneyLeft < 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotAffordAProductException, Name, product.Name));
            }

            bag.Add(product);
            money = moneyLeft;
            Console.WriteLine($"{Name} bought {product.Name}");
        }
        public override string ToString()
        {
            if (bag.Count > 0)
            {
                return $"{name} - {string.Join(", ", bag)}";
            }
            else return $"{name} - Nothing bought";
        }
    }
}
