﻿using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryEnumerator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LibraryEnumerator(this.books);
        }
    }
}