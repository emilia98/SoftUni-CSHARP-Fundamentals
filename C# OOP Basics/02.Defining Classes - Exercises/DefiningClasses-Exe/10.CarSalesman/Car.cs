using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private Engine engine;
    private double? weight; // optional
    private string color; // optional

    public string Model
    {
        get {return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public double? Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public override string ToString()
    {
        var result = new List<string>();
        var weightValue = this.Weight == null ? "n/a" : this.Weight.ToString();
        var colorValue = this.Color == null ? "n/a" : this.Color;

        result.Add($"{this.Model}: ");
        result.Add(this.Engine.ToString());
        result.Add($"  Weight: {weightValue}");
        result.Add($"  Color: {colorValue}");

        return String.Join('\n', result);
    }
}

