using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09.CustomListIterator
{
    public class CustomList<T> : IEnumerable<T>, ICustomList<T> where T : IComparable<T>
    {
        public T[] Elements { get; private set; }

        public CustomList()
        {
            Elements = new T[0];
        }

        public void Add(T element)
        {
            int currentLength = this.Elements.Length;
            T[] array = new T[currentLength + 1];
            this.Elements.CopyTo(array, 0);
            array[currentLength] = element;
            this.Elements = new T[currentLength + 1];
            array.CopyTo(this.Elements, 0);
        }

        public bool Contains(T element)
        {
            foreach(var e in this.Elements)
            {
                if(element.CompareTo(e) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            foreach(var e in this.Elements)
            {
                if(element.CompareTo(e) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            return this.Elements.OrderByDescending(x => x).ToList()[0];
        }

        public T Min()
        {
            return this.Elements.OrderBy(x => x).ToList()[0];
        }

        public T Remove(int index)
        {
            var modifiedList = new List<T>();
            T removedElement = default(T);

            for(int i = 0; i < this.Elements.Length; i++)
            {
                if(i != index)
                {
                    modifiedList.Add(this.Elements[i]);
                }
                else
                {
                    removedElement = this.Elements[i];
                }
            }

            this.Elements = modifiedList.ToArray();
            return removedElement;
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.Elements[index1];
            this.Elements[index1] = this.Elements[index2];
            this.Elements[index2] = temp;
        }

        public void Sort()
        {
            this.Elements = Sorter.Sort(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomListEnumerator(this);
        }

        public class CustomListEnumerator : IEnumerator<T>
        {
            private readonly CustomList<T> list;
            private int currentIndex;

            public CustomListEnumerator(CustomList<T> list)
            {
                this.Reset();
                this.list = list;
            }

            public T Current => this.list.Elements[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext() => ++this.currentIndex < this.list.Elements.Count();

            public void Reset() => this.currentIndex = -1;
        }
        /*
        public void Print()
        {
            foreach(var element in this.Element)
            {
                Console.WriteLine(element);
            }
        }
        */
    }
}