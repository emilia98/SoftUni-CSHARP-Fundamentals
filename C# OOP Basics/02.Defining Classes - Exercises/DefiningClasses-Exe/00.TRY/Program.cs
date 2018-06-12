using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var rectangles = new Dictionary<string, Rectangle>();
        var linesData = Console.ReadLine();
        var inputTokens = linesData.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(inputTokens[0]);
        int m = int.Parse(inputTokens[1]);

        for (int line = 1; line <= n; line++)
        {
            string input = Console.ReadLine();
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string id = tokens[0];
            double width = double.Parse(tokens[1]);
            double height = double.Parse(tokens[2]);
            double x = double.Parse(tokens[3]);
            double y = double.Parse(tokens[4]);

            var rectangle = new Rectangle()
            {
                id = id,
                width = width,
                height = height,
                y = y,
                x = x
            };
            
            rectangles.Add(id, rectangle);
        }
        
        for (int line = 1; line <= m; line++)
        {
            string input = Console.ReadLine();
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string rectId_1 = tokens[0];
            string rectId_2 = tokens[1];

            var rect1 = rectangles[rectId_1];
            var rect2 = rectangles[rectId_2];

            Console.WriteLine(PrintResult(rect1, rect2));

        }
    }
    static string PrintResult(Rectangle rectA, Rectangle rectB)
    {
        var leftMost = rectA.x <= rectB.x ? rectA.id : rectB.id;
        var notLeftMost = rectA.x > rectB.x ? rectA.id : rectB.id;
        var topMost = rectA.y >= rectB.y ? rectA.id : rectB.id;
        var notTopMost = rectA.y < rectB.y ? rectA.id : rectB.id;

        
        var rects = new Dictionary<string, Rectangle>();
        rects.Add(rectA.id, rectA);
        rects.Add(rectB.id, rectB);
        
        var leftMostRect = rects[leftMost];
        var onRight = rects[notLeftMost];
        var topMostRect = rects[topMost];
        var onBottom = rects[notTopMost];

        if (leftMostRect.x <= onRight.x &&
            onRight.x <= leftMostRect.x + leftMostRect.width
           && topMostRect.y >= onBottom.y
           && onBottom.y >= topMostRect.y - topMostRect.height)
        {
            return "true";
        }

        return "false";
    }
}


