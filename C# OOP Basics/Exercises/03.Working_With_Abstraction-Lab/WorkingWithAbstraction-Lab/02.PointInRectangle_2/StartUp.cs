using System;
using System.Linq;

namespace _02.PointInRectangle_2
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var rectCoordinates = input.Split(new char[] { ' ' },
                                              StringSplitOptions.RemoveEmptyEntries)
                                       .Select(double.Parse)
                                       .ToArray();

            Point topLeftPoint = new Point()
            {
                X = rectCoordinates[0],
                Y = rectCoordinates[1]
            };
            Point bottomRightPoint = new Point()
            {
                X = rectCoordinates[2],
                Y = rectCoordinates[3]
            };
            Rectangle rectangle = new Rectangle()
            {
                UpperLeftCorner = topLeftPoint,
                LowerRightCorner = bottomRightPoint
            };

            int pointsCount = int.Parse(Console.ReadLine());

            for (int cnt = 1; cnt <= pointsCount; cnt++)
            {
                input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                double x = double.Parse(tokens[0]);
                double y = double.Parse(tokens[1]);
                Point point = new Point()
                {
                    X = x,
                    Y = y
                };
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
