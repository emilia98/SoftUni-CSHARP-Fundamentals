using System;
using System.Collections.Generic;

namespace IComparable_Simple
{
    public class StartUp
    {
        static void Main()
        {
            var sortedSet = new SortedSet<Book>();

            sortedSet.Add(new Book { Title = "Percy Jackson", Author = "Rick Riordan" });
            sortedSet.Add(new Book { Title = "Hunger Games", Author = "Suzanne Collins" });
            sortedSet.Add(new Book { Title = "Harry Potter", Author = "J.K. Rowling" });
            sortedSet.Add(new Book { Title = "Cane Chronicles", Author = "Rick Riordan" });

            foreach (var book in sortedSet)
            {
                Console.WriteLine($"{book.Author} -> {book.Title}");
            }
        }
    }
}