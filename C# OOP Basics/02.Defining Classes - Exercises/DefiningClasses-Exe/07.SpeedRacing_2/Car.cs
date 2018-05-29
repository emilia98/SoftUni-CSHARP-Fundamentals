using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double consumptionPerKm;
    private double distanceTravelled = 0;


    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double ConsumptionPerKm
    {
        get { return this.consumptionPerKm;  }
        set { this.consumptionPerKm = value; }
    }

    public double DistanceTravelled
    {
        get { return this.distanceTravelled; }
        set { this.distanceTravelled = value; }
    }

    public void Move(double distance)
    {
        double totalFuelConsumption = distance * this.ConsumptionPerKm;

        if(totalFuelConsumption > this.FuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
            return;
        }

        this.FuelAmount -= totalFuelConsumption;
        this.DistanceTravelled += distance;
        // return true;
    }
}
