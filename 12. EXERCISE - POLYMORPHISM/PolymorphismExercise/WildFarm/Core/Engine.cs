namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildFarm.Exceptions;
    using WildFarm.Models.Animals.Contracts;
    using WildFarm.Models.Animals.Entities;
    using WildFarm.Models.Foods.Contracts;
    using WildFarm.Models.Foods.Factory;

    public class Engine
    {
        private List<Animal> animals;
        private FoodFactory foodFactory;
        public Engine()
        {
            animals = new List<Animal>();
            foodFactory = new FoodFactory();
        }
        public void Run()
        {
            var command = Console.ReadLine();

            while (command!="End")
            {
                var foodInput = Console.ReadLine();

                var animal = GetAnimal(command);
                var food = GetFood(foodInput);

                Console.WriteLine(animal.AskFood());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private IFood GetFood(string foodInput)
        {
            var foodArgs = foodInput
                .Split()
                .ToArray();

            var foodType = foodArgs[0];
            var quantity = int.Parse(foodArgs[1]);

            var food = foodFactory.ProduceFood(foodType, quantity);

            return food;
        }

        private Animal GetAnimal(string command)
        {
            var animalArg = command
                                .Split()
                                .ToArray();
            var type = animalArg[0];
            var name = animalArg[1];
            var weight = double.Parse(animalArg[2]);

            Animal animal;

            if (type == "Owl")
            {
                var wingSize = double.Parse(animalArg[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                var wingSize = double.Parse(animalArg[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                var livingRegion = animalArg[3];

                if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    var breed = animalArg[4];

                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    else throw new InvalidOperationException("Invalid Animal Type!");
                }
            }
            animals.Add(animal);
            return animal;
        }
    }
}
