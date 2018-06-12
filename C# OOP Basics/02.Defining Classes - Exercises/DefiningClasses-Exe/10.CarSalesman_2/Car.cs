using System;
using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private double? weight = null;
    private string color = null;
    
    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
    }

    public Car(string model, Engine engine, double? weight) :this(model, engine)
    {
        this.weight = weight;
    }

    public Car(string model, Engine engine, string color) :this(model, engine)
    {
        this.color = color;
    }

    public Car(string model, Engine engine, double? weight, string color) :this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        var list = new List<string>();
        var weightValue = this.weight == null ? "n/a" : this.weight.ToString();
        var colorValue = this.color == null ? "n/a" : this.color;

        list.Add($"{this.model}:");
        list.Add($"{this.engine.ToString()}");
        list.Add($"  Weight: {weightValue}");
        list.Add($"  Color: {colorValue}");

        return String.Join('\n', list);
    }
}

