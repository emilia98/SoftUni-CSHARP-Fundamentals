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
                double oldFuelValue = this.fuelAmount;

                this.CheckForFullTank(value - oldFuelValue);
                this.fuelAmount = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public double Distance { get; private set; }

        public double TankCapacity { get; private set; }

        protected Vehicle(double fuelAmount, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            try
            {
                this.FuelAmount = fuelAmount;
            }
            catch(ArgumentException e)
            {
                this.FuelAmount = 0;
            }
            
            this.FuelConsumption = fuelConsumption;
            this.Distance = 0;
        }

        protected void CheckForFullTank(double fuelAmount)
        {
            double newAmount = this.FuelAmount + fuelAmount;

            if (newAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
        }

        public virtual void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            MoveTheVehicle(fuelNeeded, distance);
        }

        protected void MoveTheVehicle(double fuelNeeded, double distance)
        {
            if (fuelNeeded > this.FuelAmount)
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
                CheckForFullTank(fuelAmount);

                this.FuelAmount += fuelAmount;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void CheckFuelAmount(double fuelAmount)
        {
            if(fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelAmount:f2}";
        }
    }
}