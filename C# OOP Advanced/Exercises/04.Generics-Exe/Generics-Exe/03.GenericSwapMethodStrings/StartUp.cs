using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
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

            string swapCommand = Console.ReadLine();
            var tokens = swapCommand.Split(' ').ToList();

            int index1 = int.Parse(tokens[0]);
            int index2 = int.Parse(tokens[1]);
            boxes = Box<string>.SwapBoxes(boxes, index1, index2);

            foreach(var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}