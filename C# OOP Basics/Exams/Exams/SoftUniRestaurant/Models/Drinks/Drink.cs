namespace SoftUniRestaurant.Models.Drinks
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using System;

    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;
        // Name – string (If the name is null or whitespace 
        // throw an ArgumenException with message "Name cannot be null or white space!")
        // ServingSize – int (if the serving size is less than or equal to 0, 
        // throw an ArgumentException with message "Serving size cannot be less or equal to zero")
        // Price – decimal (if the price is less than or equal to 0, 
        // throw an ArgumentException with message "Price cannot be less or equal to zero")
        // Brand -  string (If the brand is null or whitespace thrown ArgumentException 
        // with message "Brand cannot be null or white space!")

        public string Name
        {
            get { return this.name; }
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
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero");
                }

                this.price = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }

                this.brand = value;
            }
        }

        // string name, int servingSize, decimal price, string brand
        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} - {2}ml - {3}lv",
                                 this.Name, this.Brand, this.ServingSize, this.Price);
        }
    }
}
