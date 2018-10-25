using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    class Point
    {
        private double x;
        private double y;
        
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return this.x; }
        }

        public double Y
        {
            get { return this.y; }
        }
    }
}
