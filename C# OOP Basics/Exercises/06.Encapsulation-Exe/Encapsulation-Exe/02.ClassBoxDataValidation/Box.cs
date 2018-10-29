using System;

namespace _02.ClassBoxDataValidation
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        private double Length
        {
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        private double Width
        {
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        private double Height
        {
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double FindSurfaceArea()
        {
            return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
        }

        public double FindLateralSurfaceArea()
        {
            return 2 * this.height * (this.length + this.width);
        }

        public double FindVolume()
        {
            return this.length * this.width * this.height;
        }
    }
}