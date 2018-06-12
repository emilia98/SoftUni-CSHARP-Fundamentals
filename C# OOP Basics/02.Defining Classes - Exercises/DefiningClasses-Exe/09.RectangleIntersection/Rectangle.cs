using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private Point point;

    
    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public Point Point
    {
        get { return this.point; }
        set { this.point = value; }
    }
    

    public bool CheckIfIntersects(Rectangle rect)
    {
        
        var pointsA = Initialize(this);
        var pointsB = Initialize(rect);


        
       
    }

    /*
    private Dictionary<string, Point> Initialize(Rectangle rect)
    {
        var points = new Dictionary<string, Point>();

        points.Add("topLeft", new Point() { X = rect.Point.X, Y = rect.Point.Y });
        points.Add("topRight", new Point() { X = rect.Point.X + rect.Width, Y = rect.Point.Y });
        points.Add("bottomLeft", new Point() { X = rect.Point.X, Y = rect.Point.Y - rect.Height });
        points.Add("bottomRight", new Point() { X = rect.Point.X + rect.Width,
                                                     Y = rect.Point.Y - rect.Height });
        return points;
    }
    */

    private List<Point> Initialize(Rectangle rect)
    {
        var points = new List<Point>();

        points.Add(new Point() { X = rect.Point.X, Y = rect.Point.Y });
        points.Add( new Point() { X = rect.Point.X + rect.Width, Y = rect.Point.Y });
        points.Add(new Point() { X = rect.Point.X, Y = rect.Point.Y - rect.Height });
        points.Add(new Point()
        {
            X = rect.Point.X + rect.Width,
            Y = rect.Point.Y - rect.Height
        });
        return points;
    }

    /*
    private Dictionary<string, List<double>> Initialize(Rectangle rect)
    {
        var points = new Dictionary<string, List<double>>();
        points.Add("topLeft", new List<double> { rect.Point.X, rect.Point.Y });
        points.Add("topRight", new List<double> { rect.Point.X + rect.Width, rect.Point.Y });
        points.Add("bottomLeft", new List<double> { rect.Point.X, rect.Point.Y - rect.Height });
        points.Add("bottomRight", new List<double> { rect.Point.X + rect.Width,
                                                     rect.Point.Y - rect.Height });
        return points;
    }
    */

    private bool Check(Dictionary<string, Point> pointsA, Dictionary<string, Point> pointsB)
    {
        var topLeft = pointsA["topLeft"];
        var topRight = pointsA["topRight"];
        var bottomLeft = pointsA["bottomLeft"];
        var bottomRight = pointsA["bottomRight"];
        

        foreach(var pointsInfo in pointsB)
        {
            Point currentPoint = pointsInfo.Value;
            double x = currentPoint.X;
            double y = currentPoint.Y;


            if( (x >= topLeft.X && x <= topRight.X && y == topRight.Y) ||
                (x >= topLeft.X && x <= topRight.X && y == bottomRight.Y) ||
                (y >= bottomLeft.Y && y <= topLeft.Y && x == topLeft.X) ||
                (y >= bottomRight.Y && y <= topRight.Y && x == topRight.X)
                )
        }
        foreach (var pointInfo in pointsA)
        {
            Point.Check()
            Console.WriteLine(pointName);
        }
    }
}

