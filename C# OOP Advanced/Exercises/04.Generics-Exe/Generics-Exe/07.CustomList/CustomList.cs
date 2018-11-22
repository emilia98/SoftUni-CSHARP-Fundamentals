using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.CustomList
{
    public class CustomList<T> : ICustomList<T> where T : IComparable<T>
    {
        public List<T> CList { get; private set; }

        public CustomList()
        {
            CList = new List<T>();
        }

        public void Add(T element)
        {
            this.CList.Add(element);
        }

        public bool Contains(T element)
        {
            foreach(var e in this.CList)
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

            foreach(var e in this.CList)
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
            return this.CList.OrderByDescending(x => x).ToList()[0];
        }

        public T Min()
        {
            return this.CList.OrderBy(x => x).ToList()[0];
        }

        public T Remove(int index)
        {
            var modifiedList = new List<T>();
            T removedElement = default(T);

            for(int i = 0; i < this.CList.Count; i++)
            {
                if(i != index)
                {
                    modifiedList.Add(this.CList[i]);
                }
                else
                {
                    removedElement = this.CList[i];
                }
            }

            this.CList = modifiedList;
            return removedElement;
            
            // this.CList.RemoveAt()
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.CList[index1];
            this.CList[index1] = this.CList[index2];
            this.CList[index2] = temp;
        }

        public void Print()
        {
            foreach(var element in this.CList)
            {
                Console.WriteLine(element);
            }
        }
    }
}