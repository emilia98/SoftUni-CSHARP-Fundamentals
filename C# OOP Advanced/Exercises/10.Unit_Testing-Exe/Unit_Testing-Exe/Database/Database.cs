using System;
using System.Linq;

namespace DatabaseClass
{
    public class Database
    {
        private static int elementsCount = 16;
        private int currentIndex = -1;
        private int[] storage;

        public int Elements
        {
            get { return this.currentIndex + 1; }
        }

        public int[] Storage
        {
            get { return this.storage; }
        }

        public Database(params int[] integers)
        {
            this.storage = new int[elementsCount];

            foreach(var integer in integers)
            {
                if(this.Elements > 15)
                {
                    throw new InvalidOperationException("Init array will exceed the max capacity of the array!");
                }
                this.storage[++currentIndex] = integer;
            }
        }

        public void Add(int integer)
        {
            if(currentIndex == 15)
            {
                throw new InvalidOperationException("You exceeded the max capacity of the array");
            }
            this.storage[++currentIndex] = integer;
        }

        public int Remove()
        {
            int removed = 0;
            if(currentIndex == -1)
            {
                throw new InvalidOperationException("Cannot remove an element from empty collection!");
            }

            removed = this.storage[currentIndex];
            this.storage[currentIndex] = 0;
            --currentIndex;

            return removed;
        }

        public int[] Fetch()
        {
            return this.Storage.Take(this.Elements).ToArray();
        }
    }
}