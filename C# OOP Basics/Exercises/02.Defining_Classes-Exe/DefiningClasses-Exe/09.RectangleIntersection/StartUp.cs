using System;
using System.Collections.Generic;

namespace RectangleIntersection
{
    public class StartUp
    {
        static void Main()
        {
            var rectangles = new Dictionary<string, Rectangle>();
            var inputData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int linesCount = int.Parse(inputData[0]);
            int pairs = int.Parse(inputData[1]);

            for(int cnt = 1; cnt <= linesCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string id = tokens[0];
                double width = double.Parse(tokens[1]);
                double height = double.Parse(tokens[2]);
                double x = double.Parse(tokens[3]);
                double y = double.Parse(tokens[4]);

                var rectangle = new Rectangle(id, width, height, x, y);

                if(rectangles.ContainsKey(id) == false)
                {
                    rectangles.Add(id, rectangle);
                }
            }

            for(int cnt = 1; cnt <= pairs; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string id_1 = tokens[0];
                string id_2 = tokens[1];

                var rectA = rectangles[id_1];
                var rectB = rectangles[id_2];

                if(rectA.CompareRectangles(rectB))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}