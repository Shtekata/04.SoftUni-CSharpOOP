using System;
using System.Collections.Generic;
using WildFarm.Models.Foods.Entities;

namespace WildFarm.Models.Animals.Entities
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.4;

        public override string AskFood()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
