using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;

        // FoodOrders – collection of foods accessible only by the base class.
        // DrinkOrders – collection of drinks accessible only by the base class. 
        // TableNumber – int the table number 
        // Capacity – int the table capacity(capacity can’t be less than zero.
        //      In these cases, throw an ArgumentException with message "Capacity has to be greater than 0")
        // NumberOfPeople – int the count of people who want a table
        //    (number of people cannot be less or equal to 0. 
        //     In these cases, throw an ArgumentException with message "Cannot place zero or less people!")
        // PricePerPerson – decimal the price per person for the table
        // IsReserved – bool returns true if the table is reserved
        // Price – calculated property, which calculates the price for all people

        // ERROR: SHOULD IT BE READONLY


        /*
    private ICollection<IFood> FoodOrders
    {
        get
        {
            return this.foodOrders;
        }
    }

    private ICollection<IDrink> DrinkOrders
    {
        get
        {
            return this.drinkOrders;
        }
    }*/

            // ERROR: FIELD OR PROP
        // private List<IFood> FoodOrders { get;  set; }

 //        private List<IDrink> DrinkOrders { get;  set; }

        public int TableNumber { get; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    // In these cases, throw an ArgumentException with message "Cannot place zero or less people!")
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public bool IsReserved { get; private set; }

        public decimal PricePerPerson { get; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        // int tableNumber, int capacity, decimal pricePerPerson
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();

            // this.FoodOrders = new List<IFood>();
            // this.DrinkOrders = new List<IDrink>();

            //this.IsReserved = false;
        }

        // void Reserve(int numberOfPeople)
        //  Reserves the table with the count of people given.
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        // void OrderFood(IFood food)
        // Orders the provided food(think of a way to collect all the food which is ordered).
        public void OrderFood(IFood food)
        {
            // this.foodOrders.Add(food);
            this.foodOrders.Add(food);
        }

        // void OrderDrink(IDrink drink)
        // Orders the provided drink(think of a way to collect all the drinks which are ordered).
        public void OrderDrink(IDrink drink)
        {
            // this.drinkOrders.Add(drink);
            this.drinkOrders.Add(drink);
        }

        // decimal GetBill()
        // Returns the bill for all of the ordered drinks and food.
        public decimal GetBill()
        {
            decimal totalBill = 0;
            totalBill += this.foodOrders.Sum(x => x.Price);
            totalBill += this.drinkOrders.Sum(x => x.Price);
            return totalBill;
        }

        // void Clear()	
        // Removes all of the ordered drinks and food and finally frees the table and sets the count of people to 0.
        public void Clear()
        {
           // this.foodOrders = new List<IFood>();
           // this.drinkOrders = new List<IDrink>();

            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople = 0;

            // ERROR: SHOULD RESET THE VALUE OF ISRESEVED
            this.IsReserved = false;
            // 
        }

        // string GetFreeTableInfo()
        // Return a string with the following format:
        // "Table: {table number}"
        // "Type: {table type}"
        // "Capacity: {table capacity}"
        // "Price per Person: {price per person for the current table}"
        public string GetFreeTableInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

        // string GetOccupiedTableInfo()
        // Return a string with the following format:
        // "Table: {table number}"
        // "Type: {table type}"
        // "Number of people: {table number of people}"
        // If there aren’t any food orders append the following message to the text above:
        // "Food orders: None"
        // If there are food orders:
        //"Food orders: {food orders count}"
        //Finally append each food ToString() method
        // The same logic you can use for the ordered drinks.If there aren’t any drink orders just append the message:
        // "Drink orders: None"
        // But in the other case:
        // "Drink orders: {drink orders count}"
        // Finally append each drink ToString() method.
        //          If you got confused just look in the input output examples and you will understand it 😊
        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");

                foreach (var food in this.foodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                foreach (var drink in this.drinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}