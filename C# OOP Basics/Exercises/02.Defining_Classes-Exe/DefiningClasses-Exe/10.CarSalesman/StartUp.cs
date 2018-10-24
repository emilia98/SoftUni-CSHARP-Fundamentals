using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            int enginesCount = int.Parse(Console.ReadLine());
            var enginesData = new Dictionary<string, Engine>();
            var cars = new List<Car>();

            for(int cnt = 1; cnt <= enginesCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double power = double.Parse(tokens[1]);
                Engine engine = null;

                if(tokens.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if(tokens.Length == 4)
                {
                    double displacement = double.Parse(tokens[2]);
                    string efficiency = tokens[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if(tokens.Length == 3)
                {
                    double result;

                    if(double.TryParse(tokens[2], out result))
                    {
                        double displacement = result;
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = tokens[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }

                if(engine != null)
                {
                    if(enginesData.ContainsKey(model) == false)
                    {
                        enginesData.Add(model, engine);
                    }
                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            for(int cnt = 1; cnt <= carsCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                string engineModel = tokens[1];
                var engine = enginesData[engineModel];

                Car car = null;

                if(tokens.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if(tokens.Length == 4)
                {
                    double weight = double.Parse(tokens[2]);
                    string color = tokens[3];

                    car = new Car(model, engine, weight, color);
                }
                else if(tokens.Length == 3)
                {
                    double result;

                    if(double.TryParse(tokens[2], out result))
                    {
                        double weight = double.Parse(tokens[2]);
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = tokens[2];
                        car = new Car(model, engine, color);
                    }
                }

                cars.Add(car);
            }

            Console.WriteLine(String.Join("\n", cars));
        }
    }
}