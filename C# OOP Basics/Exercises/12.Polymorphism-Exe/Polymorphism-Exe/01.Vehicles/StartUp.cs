using System;
using System.Collections.Generic;

namespace _01.Vehicles
{
    class StartUp
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        static void Main()
        {
            string carData = Console.ReadLine();
            string truckData = Console.ReadLine();
            
            Vehicle car = GenerateFactory(carData);
            Vehicle truck = GenerateFactory(truckData);

            int linesCnt = int.Parse(Console.ReadLine());

            for(int cnt = 1; cnt <= linesCnt; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string vehicleType = tokens[1];

                Vehicle vehicle = null;

                if(vehicleType == "Car")
                {
                    vehicle = car;
                }
                else if(vehicleType == "Truck")
                {
                    vehicle = truck;
                }

                if(action == "Drive")
                {
                    double distance = double.Parse(tokens[2]);

                    try
                    {
                        DriveVehicle(vehicle, distance);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if(action == "Refuel")
                {
                    double fuelAmount = double.Parse(tokens[2]);
                    RefuelVehicle(vehicle, fuelAmount);
                }
            }

            Console.WriteLine($"Car: {car.FuelAmount:f2}");
            Console.WriteLine($"Truck: {truck.FuelAmount:f2}");
        }

        public static void DriveVehicle(Vehicle vehicle, double distance)
        {
            if(vehicle == null)
            {
                return;
            }

            vehicle.Drive(distance);
        }
        
        public static void RefuelVehicle(Vehicle vehicle, double fuelAmount)
        {
            if (vehicle == null)
            {
                return;
            }

            vehicle.Refuel(fuelAmount);
        }

        private static Vehicle GenerateFactory(string input)
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = tokens[0];

            double fuelAmount = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);

            switch(vehicleType)
            {
                case "Car":
                    {
                        return new Car(fuelAmount, fuelConsumption);
                    }
                case "Truck":
                    {
                        return new Truck(fuelAmount, fuelConsumption);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}