using Ferrari.Interfaces;
using Ferrari.Models;
using System;

namespace Ferrari.NewFolder
{
    public class Engine
    {
        public void Run()
        {
            var name = Console.ReadLine();
            var ferrari = new FerrariCar(name);
            Console.WriteLine(ferrari);
        }
    }
}
