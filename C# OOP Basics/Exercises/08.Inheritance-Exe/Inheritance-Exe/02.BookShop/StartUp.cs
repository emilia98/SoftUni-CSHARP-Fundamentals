using System;

namespace _02.BookShop
{
    public class StartUp
    {
        static void Main()
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            try
            {
                Book book = new Book(title, author, price);
                GoldenEditionBook goldenEdition = new GoldenEditionBook(title, author, price);

                Console.WriteLine(book);
                Console.WriteLine();
                Console.WriteLine(goldenEdition);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}