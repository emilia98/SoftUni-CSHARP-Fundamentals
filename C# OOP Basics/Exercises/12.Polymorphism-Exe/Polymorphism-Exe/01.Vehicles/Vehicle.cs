using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public double FuelAmount { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double Distance { get; private set; }

        protected Vehicle(double fuelAmount, double fuelConsumption)
        {
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.Distance = 0;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if(fuelNeeded > this.FuelAmount)
            {
                ThrowNoEnoughFuelException();
            }
            else
            {
                this.FuelAmount -= fuelNeeded;
                this.Distance += distance;
                Console.WriteLine(ShowMessage(distance));
            }
        }

        protected virtual void ThrowNoEnoughFuelException()
        {
            throw new ArgumentException("Vehicle needs refueling");
        }

        protected virtual string ShowMessage(double distance)
        {
            return $"Vehicle travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelAmount += fuelAmount;
        }
    }
}
