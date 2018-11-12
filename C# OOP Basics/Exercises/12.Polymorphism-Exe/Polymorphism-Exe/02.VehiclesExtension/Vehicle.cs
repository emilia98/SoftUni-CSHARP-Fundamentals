using System;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        protected double fuelAmount;

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set
            {
                if(value >= this.TankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {value} fuel in the tank");
                }

                this.fuelAmount = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public double Distance { get; private set; }

        public double TankCapacity { get; private set; }

        protected Vehicle(double fuelAmount, double fuelConsumption)
        {
            try
            {
                this.FuelAmount = fuelAmount;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e);
                this.FuelAmount = 0;
            }
            
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
            try
            {
                CheckFuelAmount(fuelAmount);
                this.FuelAmount += fuelAmount;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        protected void CheckFuelAmount(double fuelAmount)
        {
            if(fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}
