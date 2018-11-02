using System;
using System.Text;

namespace _02.BookShop
{
    class Book
    {
        protected string title;
        protected string author;
        protected decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                var authorTokens = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // We could have only one name
                if (authorTokens.Length == 2)
                {
                    string secondName = authorTokens[1];

                    if (secondName[0] >= '0' && secondName[0] <= '9')
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author}");
            sb.Append($"Price: {this.Price:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}