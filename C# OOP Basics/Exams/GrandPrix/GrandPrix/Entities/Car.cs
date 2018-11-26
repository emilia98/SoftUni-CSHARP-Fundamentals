using System;
using System.Collections.Generic;
using System.Text;

//namespace GrandPrix
//{
public class Car
{
    //TODO: Private setters
    //TODO: Constructor
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            if (value >= 160)
            {
                this.fuelAmount = 160;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set
        {
            this.tyre = value;
        }
    }

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }
    
    public void ReduceFuel(int trackLength, Driver driver)
    {
        this.FuelAmount = this.FuelAmount - (trackLength * driver.FuelConsumptionPerKm);
    }

    public void Refuel(double fuelAmount)
    {
       // Console.WriteLine("---- " + this.FuelAmount);
        this.FuelAmount += fuelAmount;
       // Console.WriteLine("***** " + this.FuelAmount);
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}
//}