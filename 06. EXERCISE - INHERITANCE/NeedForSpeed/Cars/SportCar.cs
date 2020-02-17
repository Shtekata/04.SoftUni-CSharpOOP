namespace NeedForSpeed.Cars
{
    class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
