﻿using System;

namespace IEnumerable_Simple
{
    public class StartUp
    {
        static void Main()
        {
            var books = new BookCollection();

            books.Add(new Book { Title = "Hunger Games" });
            books.Add(new Book { Title = "Harry Potter" });
            books.Add(new Book { Title = "Percy Jackson" });

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
