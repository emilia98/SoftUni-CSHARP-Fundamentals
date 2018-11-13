using System;

namespace _02.VehiclesExtension
{
    class StartUp
    {
        public static Car car;
        public static Truck truck;
        public static Bus bus;

        static void Main()
        {
            string carData = Console.ReadLine();
            string truckData = Console.ReadLine();
            string busData = Console.ReadLine();

            car = (Car)GenerateFactory(carData);
            truck = (Truck)GenerateFactory(truckData);
            bus = (Bus)GenerateFactory(busData);

            int linesCnt = int.Parse(Console.ReadLine());

            for(int cnt = 1; cnt <= linesCnt; cnt++)
            {
                string command = Console.ReadLine();
                var commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandTokens[0];
                string vehicleType = commandTokens[1];
                
                Vehicle vehicle = GetVehicleByType(vehicleType);
                
                switch (commandType)
                {
                    case "Drive":
                        {
                            double distance = double.Parse(commandTokens[2]);
                            Drive(vehicle, distance);
                            break;
                        }
                    case "Refuel":
                        {
                            double fuelAmount = double.Parse(commandTokens[2]);
                            Refuel(vehicle, fuelAmount);
                            break;
                        }
                    case "DriveEmpty":
                        {
                            double distance = double.Parse(commandTokens[2]);
                            DriveEmpty(bus, distance);
                            break;
                        }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        public static void Drive(Vehicle vehicle, double distance)
        {
            try
            {
                vehicle.Drive(distance);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Refuel(Vehicle vehicle, double fuelAmount)
        {
            try
            {
                vehicle.Refuel(fuelAmount);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DriveEmpty(Bus bus, double distance)
        {
            try
            {
                bus.DriveEmpty(distance);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Vehicle GetVehicleByType(string vehicleType)
        {
            if (vehicleType == "Car")
            {
                return car;
            }
            else if (vehicleType == "Truck")
            {
                return truck;
            }
            else if (vehicleType == "Bus")
            {
                return bus;
            }
            return null;
        }

        private static Vehicle GenerateFactory(string input)
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = tokens[0];

            double fuelAmount = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);
            double tankCapacity = double.Parse(tokens[3]);
            
            switch(vehicleType)
            {
                case "Car":
                    {
                        return new Car(fuelAmount, fuelConsumption, tankCapacity);
                    }
                case "Truck":
                    {
                        return new Truck(fuelAmount, fuelConsumption, tankCapacity);
                    }
                case "Bus":
                    {
                        return new Bus(fuelAmount, fuelConsumption, tankCapacity);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}