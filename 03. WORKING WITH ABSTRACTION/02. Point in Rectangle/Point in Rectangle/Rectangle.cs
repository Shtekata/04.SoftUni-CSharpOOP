using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    public class Rectangle
    {
        public Rectangle(Point topleft,Point bottomRight)
        {
            TopLeft = topleft;
            BottomRight = bottomRight;
        }
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }
        public bool Contains(Point point)
        {
            var inside = point.X >= TopLeft.X && point.X <= BottomRight.X && point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
            
            return inside;
        }
    }
}
