using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var cars = new Dictionary<string, Car>();
        
        while(n > 0)
        {
            string input = Console.ReadLine();
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            double fuelAmount = double.Parse(tokens[1]);
            double consumptionPerKm = double.Parse(tokens[2]);

            if(!cars.ContainsKey(model))
            {
                var car = new Car(model, fuelAmount, consumptionPerKm);

                cars.Add(model, car);
            }
            n--;
        }

        string command = Console.ReadLine();

        while(command != "End")
        {
            
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string cmdName = tokens[0];
            string model = tokens[1];
            double distance = double.Parse(tokens[2]);

            if(cmdName == "Drive")
            {
                if(cars.ContainsKey(model))
                {
                    var car = cars[model];

                    if(car.Move(distance) == false)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
            }
            command = Console.ReadLine();
        }

        foreach(var car in cars.Values)
        {
            Console.WriteLine($"{car.model} {car.fuelAmount:f2} {car.distanceTraveled}");
        }
    }
}

