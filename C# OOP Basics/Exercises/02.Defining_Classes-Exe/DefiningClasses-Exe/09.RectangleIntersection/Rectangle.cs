using System;
using System.Collections.Generic;
using System.Text;

namespace RectangleIntersection
{
    class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }

        public bool CompareRectangles(Rectangle rectB)
        {
            Rectangle rectA = this;
            Rectangle leftmost = rectB;
            Rectangle rightmost = rectA;
            Rectangle uppermost = rectB;
            Rectangle downmost = rectA;

            if (rectA.x < rectB.x)
            {
                leftmost = rectA;
                rightmost = rectB;
            }

            if(rectA.y > rectB.y)
            {
                uppermost = rectA;
                downmost = rectB;
            }
            
            if(leftmost.x + leftmost.width < rightmost.x)
            {
                return false;
            }

            if(uppermost.y - uppermost.height > downmost.y)
            {
                return false;
            }
            
            return true;
        }
    }
}
