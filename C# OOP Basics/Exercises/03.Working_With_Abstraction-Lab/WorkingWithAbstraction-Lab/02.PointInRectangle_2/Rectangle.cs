namespace _02.PointInRectangle_2
{
    class Rectangle
    {
        public Point UpperLeftCorner { get; set; }
        public Point LowerRightCorner { get; set; }

        public bool Contains(Point point)
        {
            bool isInHorizontal = 
                point.X >= this.UpperLeftCorner.X &&
                point.X <= this.LowerRightCorner.X;

            bool isInVertical = 
                point.Y >= this.UpperLeftCorner.Y &&
                point.Y <= this.LowerRightCorner.Y;
            
            return isInHorizontal && isInVertical;
        }
    }
}
