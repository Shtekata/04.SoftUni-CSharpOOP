using Ferrari.Interfaces;
using System;

namespace Ferrari.Models
{
    public class FerrariCar : Car
    {
        private const string MakeFerrari = "Ferrari";
        private const string ModelFerrari = "488-Spider";
        public FerrariCar(string name)
        {
            Name = name;
            Make = MakeFerrari;
            Model = ModelFerrari;
        }
        public string Name { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Gas!";
        }
        public override string ToString()
        {
            return $"{Model}/{Brakes()}/{GasPedal()}/{Name}";
        }
    }
}
