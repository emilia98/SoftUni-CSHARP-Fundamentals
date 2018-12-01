using System;
using System.Collections.Generic;

namespace IComparer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // Here we say what is the default way
            // of sorting a collection of books
            var sortedSet = new SortedSet<Book>();

            sortedSet.Add(new Book { Title = "Percy Jackson", Author = "Rick Riordan" });
            sortedSet.Add(new Book { Title = "Hunger Games", Author = "Suzanne Collins" });
            sortedSet.Add(new Book { Title = "Harry Potter", Author = "J.K. Rowling" });
            sortedSet.Add(new Book { Title = "Cane Chronicles", Author = "Rick Riordan" });

            foreach (var book in sortedSet)
            {
                Console.WriteLine($"{book.Author} -> {book.Title}");
            }

            Console.WriteLine();


            // We can override the default way of sorting a collection of Books and we can write a custom comparer for custom sorting (not the common way of sorting a collections of Books)
            var anotherSet = new SortedSet<Book>(new BookComparer());

            anotherSet.Add(new Book { Title = "Percy Jackson", Author = "Rick Riordan" });
            anotherSet.Add(new Book { Title = "Hunger Games", Author = "Suzanne Collins" });
            anotherSet.Add(new Book { Title = "Harry Potter", Author = "J.K. Rowling" });
            anotherSet.Add(new Book { Title = "Cane Chronicles", Author = "Rick Riordan" });

            foreach(var book in anotherSet)
            {
                Console.WriteLine($"{book.Title} -> {book.Author}");
            }
        }
    }
}