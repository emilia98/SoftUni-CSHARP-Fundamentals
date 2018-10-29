using System;

namespace _04.ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(value.Length == 0)
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.cost = value;
            }
        }

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
