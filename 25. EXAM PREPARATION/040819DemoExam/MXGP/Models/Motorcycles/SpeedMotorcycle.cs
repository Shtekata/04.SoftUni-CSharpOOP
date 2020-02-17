using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double MotorcycleCubicCentimeters = 125;
        private const int MotorcycleMinHp = 50;
        private const int MotorcycleMaxHp = 69;


        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, MotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < MotorcycleMinHp || value > MotorcycleMaxHp)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            } 
        }
    }
}
