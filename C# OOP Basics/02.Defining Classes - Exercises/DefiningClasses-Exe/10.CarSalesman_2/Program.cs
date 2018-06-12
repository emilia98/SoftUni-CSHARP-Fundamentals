using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var engines = new Dictionary<string, Engine>();
        var cars = new List<Car>();
        
        while(n > 0)
        {
            string command = Console.ReadLine();
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            double power = double.Parse(tokens[1]);
          
            var extractedValues = GetParamaters(tokens);
            double? displacement = extractedValues.Item1;
            string efficiency = extractedValues.Item2;

            Engine engine;

            if(displacement == null)
            {
                if(efficiency == null)
                {
                    engine = new Engine(model, power);
                }
                else
                {
                    engine = new Engine(model, power, efficiency);
                }
            }
            else
            {
                if (efficiency == null)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    engine = new Engine(model, power, displacement, efficiency);
                }
            }
            
            if(engines.ContainsKey(model) == false)
            {
                engines.Add(model, engine);
            }
            n--;
        }

        int m = int.Parse(Console.ReadLine());

        while(m > 0)
        {
            string command = Console.ReadLine();
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            string engineModel = tokens[1];
            Engine engine = engines[engineModel];
            var extractedValues = GetParamaters(tokens);
            double? weight = extractedValues.Item1;
            string color = extractedValues.Item2;

            Car car;

            if(weight == null)
            {
                if(color == null)
                {
                    car = new Car(model, engine);
                }
                else
                {
                    car = new Car(model, engine, color);
                }
            }
            else
            {
                if(color == null)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    car = new Car(model, engine, weight, color);
                }
            }

            cars.Add(car);
            m--;
        }

        foreach(var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    static Tuple<double?, string> GetParamaters(string[] tokens)
    {
        double? doubleValue = null;
        string stringValue = null;

        if (tokens.Length == 3)
        {
            bool hasSuccess = double.TryParse(tokens[2], out double result);

            if (hasSuccess)
            {
                doubleValue = result;
            }
            else
            {
                stringValue = tokens[2];
            }
        }
        else if (tokens.Length == 4)
        {
            doubleValue = double.Parse(tokens[2]);
            stringValue = tokens[3];
        }

        return new Tuple<double?, string>(doubleValue, stringValue);
    }
}

