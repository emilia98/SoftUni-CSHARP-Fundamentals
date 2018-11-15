using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Class
{
    public class MyCustomData<T>
    {
        private List<T> data;

        public MyCustomData()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T item)
        {
            this.data.Add(item);
        }

        // INDEXER
        public T this[int index]
        {
            get
            {
                return this.data[index];
            }
            set
            {
                this.data[index] = value;
            }
        }
    }
}
