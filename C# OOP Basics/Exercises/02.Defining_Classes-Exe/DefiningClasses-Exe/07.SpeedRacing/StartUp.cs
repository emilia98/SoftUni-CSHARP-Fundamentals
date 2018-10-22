using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, Car>();

            for(int cnt = 1; cnt <= carsCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double consumptionRate = double.Parse(tokens[2]);

                var car = new Car(model, fuelAmount, consumptionRate);
                cars.Add(model, car);
            }

            string command = Console.ReadLine();

            while(command != "End")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double amountKm = double.Parse(tokens[2]);

                var car = cars[model];
                car.Travel(amountKm);

                command = Console.ReadLine();
            }
            
            foreach(var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}