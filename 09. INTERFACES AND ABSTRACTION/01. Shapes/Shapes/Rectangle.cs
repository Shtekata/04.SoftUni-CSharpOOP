namespace Shapes
{
    using System;
    public class Rectangle : IDrawable
    {
        private readonly int width;
        private readonly int height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        void IDrawable.Draw()
        {
            DrawLine('*', '*');
            for (int i = 1; i < height-1; i++)
            {
                DrawLine('*', ' ');
            }
            DrawLine('*', '*');
        }
        private void DrawLine(char end, char middle)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; i++)
            {
                Console.Write(middle);
            }
            Console.WriteLine(end);
        }
    }
}
