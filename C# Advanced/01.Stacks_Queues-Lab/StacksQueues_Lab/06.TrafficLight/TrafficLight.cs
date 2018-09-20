using System;
using System.Collections.Generic;

namespace _06.TrafficLight
{
    class TrafficLight
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            var cars = new Queue<string>();
            int carsPassed = 0;
            int totalCars = 0;

            while(input != "end")
            {
                if(input == "green")
                {
                    while(carsPassed < n && cars.Count > 0)
                    {
                        Console.WriteLine("{0} passed!", cars.Dequeue());
                        totalCars++;
                        carsPassed++;
                    }

                    carsPassed = 0;
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCars} cars passed the crossroads.");
        }
    }
}
