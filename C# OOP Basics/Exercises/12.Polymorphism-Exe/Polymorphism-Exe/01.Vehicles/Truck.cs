using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelAmount, double fuelConsumption) : base(fuelAmount, fuelConsumption)
        {
            this.FuelConsumption = base.FuelConsumption + 1.6;
        }

        protected override string ShowMessage(double distance)
        {
            return $"Truck travelled {distance} km";
        }

        protected override void ThrowNoEnoughFuelException()
        {
            throw new ArgumentException("Truck needs refueling");
        }

        public override void Refuel(double fuelAmount)
        {
            this.FuelAmount += (fuelAmount * 0.95);
        }
    }
}
