using System.Collections;
using System.Collections.Generic;

namespace IEnumerable_Without_Foreach
{
    class BookCollection : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public BookCollection()
        {
            this.books = new List<Book>();
        }
        
        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new BooksEnumerator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BooksEnumerator(this.books);
        }

        public class BooksEnumerator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public BooksEnumerator(List<Book> books)
            {
                this.Reset();
                this.books = books;
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
}