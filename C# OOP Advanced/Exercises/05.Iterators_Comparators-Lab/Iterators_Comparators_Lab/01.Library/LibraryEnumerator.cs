using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryEnumerator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryEnumerator(List<Book> books)
        {
            this.books = books;
            this.Reset();
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext() => ++this.currentIndex < this.books.Count;

        public void Reset() => this.currentIndex = -1;
    }
}