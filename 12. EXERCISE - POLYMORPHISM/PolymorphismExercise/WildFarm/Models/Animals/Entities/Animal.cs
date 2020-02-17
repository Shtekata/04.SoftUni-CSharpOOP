using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Entities
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name,double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract List<Type> PrefferedFoodTypes { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskFood();
        
        public void Feed(IFood food)
        {
            if (!PrefferedFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFoodTypeException, GetType().Name, food.GetType().Name));
            }

            Weight += WeightMultiplier * food.Quantity;
            FoodEaten += food.Quantity;
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
