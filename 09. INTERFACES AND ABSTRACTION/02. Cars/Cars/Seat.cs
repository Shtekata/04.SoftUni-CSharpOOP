namespace Cars
{
    using System;
    using System.Text;

    public class Seat : Car
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} {GetType().Name} {Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
