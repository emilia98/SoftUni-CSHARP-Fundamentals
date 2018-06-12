using System;
using System.Collections.Generic;

public class Engine
{
    private string model;
    private double power;
    private double? displacement; // optional
    private string efficiency; // optional

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public double? Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

    public override string ToString()
    {
        var result = new List<string>();
        string displacementValue = this.Displacement == null ? "n/a" : this.Displacement.ToString();
        string efficiencyValue = this.Efficiency == null ? "n/a" : this.Efficiency;

        result.Add($"  {this.Model}:");
        result.Add($"    Power: {this.Power}"); 
        result.Add($"    Displacement: {displacementValue}");
        result.Add($"    Efficiency: {efficiencyValue}");

        return String.Join('\n', result);
    }
}

