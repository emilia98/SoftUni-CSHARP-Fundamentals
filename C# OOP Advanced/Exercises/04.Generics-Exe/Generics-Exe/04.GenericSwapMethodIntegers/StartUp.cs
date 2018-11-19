using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box<int>>();

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                int value = int.Parse(Console.ReadLine());

                var box = new Box<int>(value);
                boxes.Add(box);
            }

            string swapCommand = Console.ReadLine();
            var tokens = swapCommand.Split(' ').ToList();

            int index1 = int.Parse(tokens[0]);
            int index2 = int.Parse(tokens[1]);

            boxes = Box<int>.SwapBoxes(boxes, index1, index2);

            foreach(var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}