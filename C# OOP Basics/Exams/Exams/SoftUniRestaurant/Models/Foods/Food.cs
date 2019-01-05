namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;

    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;
        // Name – string (If the name is null or whitespace throw an 
        // ArgumentException with message "Name cannot be null or white space!")
        // ServingSize – int (can’t be less or equal to 0. In these cases, 
        // throw an ArgumentException with message "Serving size cannot be less or equal to zero")
        // Price – decimal (can’t be less or equal to 0. In these cases,
        // throw an ArgumentException with message "Price cannot be less or equal to zero!")

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public int ServingSize
        {
            get { return this.servingSize; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }

                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        // string ToString()
        // Returns a string with information about each food.The returned string must be in the following format:
        // "{current food name}: {current serving size}g - {current price - formatted to the second digit}" 
        public override string ToString()
        {
            return String.Format("{0}: {1}g - {2:f2}", this.Name, this.ServingSize, this.Price);
        }
    }
}
