using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double MotorcycleCubicCentimeters = 450;
        private const int MotorcycleMinHp = 70;
        private const int MotorcycleMaxHp = 100;

        private int horsePower;
        public PowerMotorcycle(string model, int horsePower)
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
