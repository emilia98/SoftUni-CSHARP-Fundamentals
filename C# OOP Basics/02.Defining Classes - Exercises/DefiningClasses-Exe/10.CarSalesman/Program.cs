using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var enginesInfo = new Dictionary<string, Engine>();
        var cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for(int line = 1; line <= n; line++)
        {
            string command = Console.ReadLine();
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            double power = double.Parse(tokens[1]);
            double? displacement = null;
            string efficiency = null;

            if (tokens.Length == 3)
            {
                bool hasSuccess = double.TryParse(tokens[2], out double result);

                // hasSuccess == true ? displacement = result : efficiency = tokens[2];
                if(hasSuccess)
                {
                    displacement = result;
                }
                else
                {
                    efficiency = tokens[2];
                }
            }
            else if(tokens.Length == 4)
            {
                displacement = double.Parse(tokens[2]);
                efficiency = tokens[3];
            }

            var engine = new Engine();
            engine.Model = model;
            engine.Power = power;
            engine.Displacement = displacement;
            engine.Efficiency = efficiency;

            if(!enginesInfo.ContainsKey(model))
            {
                enginesInfo.Add(model, engine);
            }
        }

        int m = int.Parse(Console.ReadLine());

        for(int line = 1; line <= m; line++)
        {
            string command = Console.ReadLine();
            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            string engineName = tokens[1];
            Engine engine = enginesInfo[engineName];
            double? weight = null;
            string color = null;

            if(tokens.Length == 3)
            {
                bool hasSuccess = double.TryParse(tokens[2], out double result);

                if(hasSuccess)
                {
                    weight = result;
                }
                else
                {
                    color = tokens[2];
                }
            }
            else if(tokens.Length == 4)
            {
                weight = double.Parse(tokens[2]);
                color = tokens[3];
            }

            var car = new Car()
            {
                Model = model,
                Engine = engine,
                Weight = weight,
                Color = color
            };
            
            cars.Add(car);
        }

        foreach(var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}

