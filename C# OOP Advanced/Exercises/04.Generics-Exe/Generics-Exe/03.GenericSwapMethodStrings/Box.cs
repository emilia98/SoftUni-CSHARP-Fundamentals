using System;
using System.Collections.Generic;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        public T Value { get; private set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Value.GetType().FullName, this.Value
                );
        }

        public static List<Box<T>> SwapBoxes(List<Box<T>> boxes, int index1, int index2)
        {
            var temp = boxes[index1];
            boxes[index1] = boxes[index2];
            boxes[index2] = temp;

            return boxes;
        }
    }
}