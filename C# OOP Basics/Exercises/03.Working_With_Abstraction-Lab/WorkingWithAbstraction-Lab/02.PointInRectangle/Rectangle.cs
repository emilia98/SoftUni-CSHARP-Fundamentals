using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public Point TopLeft
        {
            get { return this.topLeft; }
        }

        public Point BottomRight
        {
            get { return this.bottomRight; }
        }

        public bool Contains(Point point)
        {
            if(this.TopLeft.X <= point.X && this.BottomRight.X >= point.X &&
                this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y)
            {
                return true;
            }

            return false;
        }
    }
}
