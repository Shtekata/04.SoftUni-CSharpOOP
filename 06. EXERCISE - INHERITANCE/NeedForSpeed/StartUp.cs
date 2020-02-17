using NeedForSpeed.Motorcycles;
using NeedForSpeed.Cars;
using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var v = new Vehicle(150, 100);
            v.Drive(10);
            Console.WriteLine(v.Fuel);

            var c = new CrossMotorcycle(150, 100);
            c.Drive(10);
            Console.WriteLine(c.Fuel);

            var m = new RaceMotorcycle(150, 100);
            m.Drive(10);
            Console.WriteLine(m.Fuel);

            var car = new Car(150, 100);
            car.Drive(10);
            Console.WriteLine(car.Fuel);

            var familyCar = new FamilyCar(150, 100);
            familyCar.Drive(10);
            Console.WriteLine(familyCar.Fuel);

            var sportCar = new SportCar(150, 100);
            sportCar.Drive(10);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
