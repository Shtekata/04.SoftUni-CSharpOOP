using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private readonly int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public void Draw()
        {
            var tickness = 0.4;
            var rIn = radius - tickness;
            var rOut = radius + tickness;

            for (int y = radius; y >= -radius; y--)
            {
                for (double x = -radius; x <= radius; x += 0.5)
                {
                    var point = x * x + y * y;

                    if (point >= rIn * rIn && point <= rOut * rOut)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
