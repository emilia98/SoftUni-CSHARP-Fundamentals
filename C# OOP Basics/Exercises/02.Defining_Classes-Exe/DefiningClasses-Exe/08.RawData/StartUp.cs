using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int linesCnt = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for(int cnt = 1; cnt <= linesCnt; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];

                int enginePower = int.Parse(tokens[1]);
                int engineSpeed = int.Parse(tokens[2]);
               

                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                
                var tires = new List<Tire>();

                for(int index = 5; index <= 12; index += 2)
                {
                    double pressure = double.Parse(tokens[index]);
                    int age = int.Parse(tokens[index + 1]);

                    var tire = new Tire(pressure, age);
                    tires.Add(tire);
                }

                var engine = new Engine(enginePower, engineSpeed);
                var cargo = new Cargo(cargoType, cargoWeight);
                var car = new Car(model, engine, cargo, tires.ToArray());

                cars.Add(car);
            }

            string command = Console.ReadLine();

            var result = new List<Car>();

            if(command == "fragile")
            {
                foreach(var car in cars)
                {
                    bool hasFound = false;

                    if (car.Cargo.Type == command)
                    {
                        foreach(var tire in car.Tires)
                        {
                            if(tire.Pressure < 1)
                            {
                                hasFound = true;
                                break;
                            }
                        }

                        if(hasFound)
                        {
                            result.Add(car);
                        }
                    }
                }
            }
            else if(command == "flamable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == command && car.Engine.Power > 250)
                    {
                        result.Add(car);
                    }
                }
            }

            foreach(var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
