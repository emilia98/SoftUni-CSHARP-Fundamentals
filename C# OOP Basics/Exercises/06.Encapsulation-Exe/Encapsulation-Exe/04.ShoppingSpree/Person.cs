using System;
using System.Collections.Generic;
using System.Text;

namespace _04.ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Bag
        {
            get { return this.bag; }
        }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public void AddProductToBag(Product product)
        {
            if(product.Cost <= this.Money)
            {
                this.Bag.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
