using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var modelsAdded = new List<string>();
        var cars = new List<Car>();

        for(int line = 1; line <= n; line++)
        {
            string input = Console.ReadLine();
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            double fuelAmount = double.Parse(tokens[1]);
            double consumptionPerKm = double.Parse(tokens[2]);

            int modelIndex = modelsAdded.IndexOf(model);

            if (modelIndex == -1)
            {
                var car = new Car();
                car.Model = model;
                car.FuelAmount = fuelAmount;
                car.ConsumptionPerKm = consumptionPerKm;
                
                cars.Add(car);
                modelsAdded.Add(model);
            }
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string cmdName = tokens[0];
            string model = tokens[1];
            double distance = double.Parse(tokens[2]);

            if (cmdName == "Drive")
            {
                int modelIndex = modelsAdded.IndexOf(model);

                if (modelIndex > -1)
                {
                    var car = cars[modelIndex];
                    car.Move(distance);
                }
            }
            command = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine("{0} {1:f2} {2}",
                car.Model, car.FuelAmount, car.DistanceTravelled);
        }
    }
}

