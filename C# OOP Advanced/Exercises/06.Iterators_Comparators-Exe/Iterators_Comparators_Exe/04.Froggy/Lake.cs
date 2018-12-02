using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(params int[] stones)
        {
            this.stones = new List<int>(stones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LakeEnumerator(this.stones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LakeEnumerator : IEnumerator<int>
        {
            private readonly List<int> elements;
            private int lastEvenIndex;
            private int lastOddIndex;
            private int currentIndex;

            private bool hasEndedEvens = false;

            public LakeEnumerator(ICollection<int> elements)
            {
                this.elements = new List<int>(elements);
                this.InitIndexes();
                this.Reset();
            }

            public void InitIndexes()
            {
                int lastIndex = this.elements.Count - 1;

                if(lastIndex % 2 == 0)
                {
                    this.lastEvenIndex = lastIndex;
                    this.lastOddIndex = lastIndex - 1;
                }
                else
                {
                    this.lastOddIndex = lastIndex;
                    this.lastEvenIndex = lastIndex - 1;
                }
            }

            public int Current => this.elements[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {}

            public bool MoveNext()
            {
                if(hasEndedEvens == false && this.currentIndex >= -2 && this.currentIndex < this.lastEvenIndex)
                {
                    this.currentIndex += 2;
                    return true;
                }

                if(hasEndedEvens == false && this.currentIndex >= this.lastEvenIndex)
                {
                    if(lastOddIndex < 0)
                    {
                        return false;
                    }

                    this.hasEndedEvens = true;
                    this.currentIndex = this.lastOddIndex;
                    return true;
                }

                if(hasEndedEvens && this.currentIndex <= this.lastOddIndex && this.currentIndex >= 3)
                {
                    this.currentIndex -= 2;
                    return true;
                }

                return false;
            }

            public void Reset() => this.currentIndex = -2;
        }
    }
}
