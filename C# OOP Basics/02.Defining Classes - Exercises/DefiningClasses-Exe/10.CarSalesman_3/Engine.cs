using System;
using System.Collections.Generic;

public class Engine
{
    private string model;
    private double power;
    private double? displacement;
    private string efficiency;
    
    public Engine(string model, double power, double? displacement, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        var list = new List<string>();

        var displacementValue = this.displacement == null ? "n/a" : this.displacement.ToString();
        var efficiencyValue = this.efficiency == null ? "n/a" : this.efficiency;

        list.Add($"  {this.model}:");
        list.Add($"    Power: {this.power}");
        list.Add($"    Displacement: {displacementValue}");
        list.Add($"    Efficiency: {efficiencyValue}");

        return String.Join('\n', list);
    }
}

