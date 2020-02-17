namespace ClassBoxData.Models
{
    using System;
    using System.Text;
    using ClassBoxData.Exceptions;
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length,double width,double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get =>length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LengthZeroOrNegativeException);
                } 

                else length = value;
            }
        }
        public double Width
        {
            get =>width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }
                    
                else width = value;
            }
        }
        public double Height
        {
            get =>height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HightZeroOrNegativeExeption);
                }
                    
                else height = value;
            }
        }
        public double SurfaceArea()
        {
            return length * width * 2 + length * height * 2 + width * height * 2;
        }
        public double LateralSurfaceArea()
        {
            return SurfaceArea() - length * width * 2;
        }
        public double Volume()
        {
            return length * height * width;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
