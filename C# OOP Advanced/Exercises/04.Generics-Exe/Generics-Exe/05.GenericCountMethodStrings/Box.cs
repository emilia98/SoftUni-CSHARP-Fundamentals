using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public T Value { get; private set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Value.GetType().FullName, this.Value);
        }

        public static int CountGreater(List<Box<T>> boxes, T comparable)
        {
            int counter = 0;

            foreach(var box in boxes)
            {
                if(box.Value.CompareTo(comparable) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

    }
}