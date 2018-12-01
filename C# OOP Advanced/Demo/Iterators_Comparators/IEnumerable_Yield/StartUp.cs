using System;

namespace IEnumerable_Yield
{
    public class StartUp
    {
        static void Main()
        {
            var books = new BooksCollection();

            books.Add(new Book { Title = "Hunger Games" });
            books.Add(new Book { Title = "Harry Potter" });
            books.Add(new Book { Title = "Percy Jackson" });
            books.Add(new Book { Title = "Wimpy Kid Diaries" });

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
