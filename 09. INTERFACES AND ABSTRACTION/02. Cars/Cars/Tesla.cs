using System;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public int Battery { get; set; }

        public Tesla(string model,string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} {GetType().Name} {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
