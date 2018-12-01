using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book book_a, Book book_b)
        {
            int result = book_a.Title.CompareTo(book_b.Title);
            
            if(result == 0)
            {
                return book_b.Year.CompareTo(book_a.Year);
            }

            return result;
        }
    }
}