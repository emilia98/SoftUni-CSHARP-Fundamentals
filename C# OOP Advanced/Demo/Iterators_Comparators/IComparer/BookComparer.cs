using System;
using System.Collections.Generic;
using System.Text;

namespace IComparer
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
