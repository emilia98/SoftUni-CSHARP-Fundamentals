using System;

namespace _02.GenericBoxOfIntegers
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
            return String.Format("{0}: {1}", this.Value.GetType().FullName, this.Value);
        }
    }
}