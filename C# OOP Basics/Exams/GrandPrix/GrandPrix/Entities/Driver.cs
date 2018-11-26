using System;
using System.Collections.Generic;
using System.Text;

//namespace GrandPrix
//{
public abstract class Driver
{
    public string Name { get; private set; }

    public double TotalTime { get; private set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public double Speed { get; protected set; }

    public Failure Failure { get; private set; }

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = 1;
        this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        this.Failure = null;

        // Console.WriteLine("BASE Speeeed = {0}", this.Speed);
    }

    public virtual void ChangeSpeed()
    {/*
        if (this.Car.FuelAmount == 0)
        {
            this.Speed = 0;
            return;
        }*/
        this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    }

    public void IncreaseTotalTime(int trackLength)
    {
        ChangeSpeed();
        this.TotalTime += 60 / (trackLength / this.Speed);

    }

    public void SetFailure(string failureType)
    {
        this.Failure = new Failure(failureType);
    }

    public void Overtake(int seconds)
    {
        this.TotalTime -= seconds;
    }

    public void BeOvertaken(int seconds)
    {
        this.TotalTime += seconds;
    }

    public void VisitBox()
    {
        this.TotalTime += 20;
    }
}
//}