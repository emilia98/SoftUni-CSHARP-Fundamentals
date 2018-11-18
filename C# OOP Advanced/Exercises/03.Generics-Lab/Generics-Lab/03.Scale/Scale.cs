using System;

namespace GenericScale
{
    public class Scale<T> where T : IComparable<T>
    {
        public T Left { get; private set; }

        public T Right { get; private set; }

        public Scale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T GetHeavier() 
        {
            var result = this.Left.CompareTo(this.Right);

            /*
            switch(result)
            {
                case 0:  return default(T);
                case 1: return this.Left;
                case -1: return this.Right;
            }*/
            if (result == 0)
            {
                return default(T);
            }
            else if (result > 0)
            {
                return this.Left;
            }


            return this.Right;
        }
    }
}