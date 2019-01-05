using System;
using System.Linq;
using SoftUniRestaurant.IO;
using SoftUniRestaurant.Core;

namespace AnimalCentre.Core
{
    public class Engine

    {
        private RestaurantController restaurantController;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.restaurantController = new RestaurantController();
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = String.Empty;
            while ((command = this.reader.readData()) != "END")
            {

                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    // this.writer.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine(e.Message);
                }

            }

            this.writer.WriteLine(this.restaurantController.GetSummary());
           // this.writer.WriteLine(this..AdoptedAnimals());
        }
        private void ReadCommand(string command)
        {
            string[] tokens = command.Split(" ");
            var output = String.Empty;
            string[] data = tokens.Skip(1).ToArray();

            switch (tokens[0])
            {
                // •	AddFood {type} {name} {price}
                case "AddFood":
                    {
                        string type = data[0];
                        string name = data[1];
                        decimal price = decimal.Parse(data[2]);
                        output = this.restaurantController.AddFood(type, name, price); ;
                        break;
                    }
                // •	AddDrink {type} {name} {servingSize} {brand}
                case "AddDrink":
                    {
                        string type = data[0];
                        string name = data[1];
                        int servingSize = int.Parse(data[2]);
                        string brand = data[3];
                        output = this.restaurantController.AddDrink(type, name, servingSize, brand);
                        break;
                    }
                // •	AddTable {type} {tableNumber} {capacity}
                case "AddTable":
                    {
                        string type = data[0];
                        int tableNumber = int.Parse(data[1]);
                        int capacity = int.Parse(data[2]);
                        output = this.restaurantController.AddTable(type, tableNumber, capacity);
                        break;
                    }
                // •	ReserveTable {numberOfPeople}
                case "ReserveTable":
                    {
                        int numberOfPeople = int.Parse(data[0]);
                        output = this.restaurantController.ReserveTable(numberOfPeople);
                        break;
                    }
                // •	OrderFood {tableNumber} {foodName}
                case "OrderFood":
                    {
                        int tableNumber = int.Parse(data[0]);
                        string foodName = data[1];
                        output = this.restaurantController.OrderFood(tableNumber, foodName);
                        break;
                    }
                // •	OrderDrink {tableNumber} {drinkName} {drinkBrand}
                case "OrderDrink":
                    {
                        int tableNumber = int.Parse(data[0]);
                        string drinkName = data[1];
                        string drinkBrand = data[2];
                        output = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                        break;
                    }
                // •	LeaveTable {tableNumber}
                case "LeaveTable":
                    {
                        int tableNumber = int.Parse(data[0]);
                        output = this.restaurantController.LeaveTable(tableNumber);
                        break;
                    }
                // •	GetFreeTablesInfo
                case "GetFreeTablesInfo":
                    {
                        output = this.restaurantController.GetFreeTablesInfo();
                        break;
                    }
                // •	GetOccupiedTablesInfo
                case "GetOccupiedTablesInfo":
                    {
                        output = this.restaurantController.GetOccupiedTablesInfo();
                        break;
                    }
            }
            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}