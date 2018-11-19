using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                string value = Console.ReadLine();

                var box = new Box<string>(value);
                boxes.Add(box);
            }

            string comparable = Console.ReadLine();
            int greaterCount = Box<string>.CountGreater(boxes, comparable);
            Console.WriteLine(greaterCount);
        }
    }
}