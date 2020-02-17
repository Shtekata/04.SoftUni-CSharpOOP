using Restaurant.Beverages;
using Restaurant.Foods;
using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var a = new Coffee("coffee", 35);
            Console.WriteLine($"{a.Name} {a.Price} {a.Milliliters} {a.Caffeine}");
        }
    }
}