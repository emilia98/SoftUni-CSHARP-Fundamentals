public class Car
{
    public string model;
    public double fuelAmount;
    public double consumptionPerKm;
    public double distanceTraveled = 0;


    public Car(string model, double fuelAmount, double consumptionPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.consumptionPerKm = consumptionPerKm;
    }

    public bool Move(double distance)
    {
        var totalFuelConsumption = distance * this.consumptionPerKm;

        if(totalFuelConsumption > this.fuelAmount)
        {
            return false;
        }

        this.distanceTraveled += distance;
        fuelAmount -= totalFuelConsumption;
        return true;
    }
}

