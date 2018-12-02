using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class Stack<T> : IEnumerable<T>, IStack<T>
    {
        private List<T> elements;

        public List<T> Elements
        {
            get { return this.elements; }
        }

        public Stack()
        {
            this.elements = new List<T>();
        }

        public void Pop()
        {
            int elementsCount = this.elements.Count;

            if (elementsCount == 0)
            {
                Console.WriteLine("No elements");
                return;
            }

            this.elements.RemoveAt(elementsCount - 1);
        }

        public void Push(params T[] items)
        {
            foreach(var item in items)
            {
                this.elements.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(this.elements);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private List<T> ReverseCollection()
        {
            var reversed = new List<T>();

            for(int index = this.elements.Count - 1; index >= 0; index--)
            {
                reversed.Add(this.elements[index]);
            }

            return reversed;
        }

        private class StackEnumerator : IEnumerator<T>
        {
            private readonly List<T> data;
            private int currentIndex;

            public StackEnumerator(ICollection<T> data)
            {
                this.data = new List<T>(data);
                this.Reset();
            }

            public T Current => this.data[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {}

            public bool MoveNext() => --this.currentIndex >= 0;

            public void Reset() => this.currentIndex = this.data.Count;
        }
    }
}
