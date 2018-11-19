using System;
using System.Collections.Generic;

namespace _06.GenericsCountMethodDoubles
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box<double>>();

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                double value = double.Parse(Console.ReadLine());

                var box = new Box<double>(value);
                boxes.Add(box);
            }

            double comparable = double.Parse(Console.ReadLine());
            int greatersCount = Box<double>.CountGreaters(boxes, comparable);

            Console.WriteLine(greatersCount);
        }
    }
}