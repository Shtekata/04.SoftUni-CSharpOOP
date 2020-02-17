using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> persons;
        public Engine()
        {
            products = new List<Product>();
            persons = new List<Person>();
        }
        public void Run()
        {
            try
            {
                ReadPersonsInput();
                ReadProductsInput();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                try
                {
                    var splitInput = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var targetPerson = persons.FirstOrDefault(x => x.Name == splitInput[0]);
                    var targetProduct = products.FirstOrDefault(x => x.Name == splitInput[1]);

                    if (targetPerson != null && targetProduct != null)
                    {
                        targetPerson.AddProduct(targetProduct);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, persons));

        }

        private void ReadProductsInput()
        {
            var productsInput = Console.ReadLine()
                                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            foreach (var item in productsInput)
            {
                var tokens = item
                    .Split("=");

                var name = tokens[0];
                var cost = decimal.Parse(tokens[1]);
                var product = new Product(name, cost);

                products.Add(product);
            }
        }

        private void ReadPersonsInput()
        {
            var personTokens = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            foreach (var item in personTokens)
            {
                var tokens = item
                    .Split("=");

                var name = tokens[0];
                var money = decimal.Parse(tokens[1]);
                var person = new Person(name, money);

                persons.Add(person);
            }
        }
    }
}
