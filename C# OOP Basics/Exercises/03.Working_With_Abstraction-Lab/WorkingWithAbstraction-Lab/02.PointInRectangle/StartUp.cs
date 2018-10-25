using System;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        static Rectangle rectangle = null;

        static void Main()
        {
            string input = Console.ReadLine();
            var rectCoordinates = input.Split(new char[] { ' ' }, 
                                              StringSplitOptions.RemoveEmptyEntries)
                                       .Select(double.Parse)
                                       .ToArray();

            var topLeftPoint = new Point(rectCoordinates[0], rectCoordinates[1]);
            var bottomRightPoint = new Point(rectCoordinates[2], rectCoordinates[3]);
            rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int pointsCount = int.Parse(Console.ReadLine());

            for(int cnt = 1; cnt <= pointsCount; cnt++)
            {
                input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                double x = double.Parse(tokens[0]);
                double y = double.Parse(tokens[1]);
                Point point = new Point(x, y);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
