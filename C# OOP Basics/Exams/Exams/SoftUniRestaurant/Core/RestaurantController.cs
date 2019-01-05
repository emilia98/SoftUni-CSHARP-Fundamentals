namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Factories;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;
        
        private decimal totalIncomes = 0;

        public RestaurantController()
        {
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncomes = 0;
        }
        
        public string AddFood(string type, string name, decimal price)
        {
            IFood food = this.foodFactory.CreateFactory(type, name, price);
            
            menu.Add(food);

            var classType = food.GetType().Name;

            return $"Added {name} ({type}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateFactory(type, name, servingSize, brand);
            
            drinks.Add(drink);
            // ERROR: WHICH VALUES TO USE
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateFactory(type, tableNumber, capacity);
            

            tables.Add(table);
            // ERROR: WHICH VALUES TO USE
            return $"Added table number {tableNumber} in the restaurant";
        }

        // 1) Finds a table which is not reserved, and its capacity is enough for the number of people provided. 
        // 2) If there is no such table returns: "No available table for {numberOfPeople} people"
        // 3) In the other case reserves the table and returns:
        // 4) "Table {table number} has been reserved for {numberOfPeople} people"

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(x => (x.IsReserved == false && x.Capacity >= numberOfPeople));

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
                // return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        // 1) Finds the table with that number and the food with that name in the menu. 
        // 2) If there is no such table returns: "Could not find table with {tableNumber}"
        // 3) If there is no such food returns: "No {foodName} in the menu"
        // 4) In other case orders the food for that table and returns: "Table {tableNumber} ordered {foodName}"
        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
                // return $"Could not find table with {tableNumber}";
            }

            IFood food = menu.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
                // return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            // this.menu.Remove(food); -->>???
            return $"Table {tableNumber} ordered {foodName}";
        }

        // 1) Finds the table with that number and finds the drink with that name and brand. 
        // 2) If there is no such table, it returns: "Could not find table with {tableNumber}"
        // 3) If there isn’t such drink, it returns: "There is no {drinkName} {drinkBrand} available"
        // 4) In other case, it orders the drink for that table and returns: "Table {tableNumber} ordered {drinkName} {drinkBrand}"
        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drink = drinks.FirstOrDefault(x => (x.Name == drinkName && x.Brand == drinkBrand));

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            // this.drinks.Remove(drink); -->> ????
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }
        
        // Finds the table with the same table number. Gets the bill for that table and clears it. Finally returns:
        // "Table: {tableNumber}"
        // "Bill: {table bill:f2}"
        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            
            // ERROR: NO TABLE WITH THIS NUMBER ???
            if (table == null)
            {
                return "";
            }

            decimal totalBill = table.GetBill() + table.Price;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {totalBill:f2}");
            
            this.totalIncomes += totalBill;
            table.Clear();
            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = this.tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetOccupiedTablesInfo()
        {
            List<ITable> occupiedTables = this.tables.Where(x => x.IsReserved == true).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var table in occupiedTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncomes:f2}lv";
        }
    }
}