using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int current;

        public List<T> Items { get; }

        public ListyIterator(params T[] items)
        {
            this.Items = new List<T>(items);
            this.current = 0;
        }

        public bool Move()
        {
            bool hasNext = this.HasNext();

            if(hasNext)
            {
                this.current++;
            }

            return hasNext;
        }

        public bool HasNext()
        {
            return this.current < this.Items.Count - 1;
        }

        public void Print()
        {
            if(this.Items.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(this.Items[current]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this.Items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class ListEnumerator : IEnumerator<T>
        {
            private readonly List<T> items;
            private int currentIndex;

            public ListEnumerator(ICollection<T> items)
            {
                this.items = new List<T>(items);
                this.Reset();
            }

            public T Current => this.items[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext() => ++this.currentIndex < this.items.Count;

            public void Reset() => this.currentIndex = -1;
        }
    }
}
