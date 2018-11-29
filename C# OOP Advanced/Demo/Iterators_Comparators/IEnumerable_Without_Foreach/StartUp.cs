using System;

namespace IEnumerable_Without_Foreach
{
    public class StartUp
    {
        static void Main()
        {
            var books = new BookCollection();

            books.Add(new Book { Title = "Hunger Games" });
            books.Add(new Book { Title = "Harry Potter" });
            books.Add(new Book { Title = "Percy Jackson" });

            var enumerator = books.GetEnumerator();

            enumerator.Reset();

            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}
