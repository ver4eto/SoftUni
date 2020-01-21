using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public  bool Contains (Point point)
        {
            bool insideByX = point.CoordinateX >= TopLeft.CoordinateX 
                && point.CoordinateX <= BottomRight.CoordinateX;

            bool insideByY = point.CoordinateY >= TopLeft.CoordinateY
                && point.CoordinateY <= BottomRight.CoordinateY;

            return insideByY && insideByX;
        }
    }
}
