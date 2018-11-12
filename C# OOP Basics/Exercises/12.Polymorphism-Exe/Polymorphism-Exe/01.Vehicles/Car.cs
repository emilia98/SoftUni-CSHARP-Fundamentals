using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelAmount, double fuelConsumption) : base(fuelAmount, fuelConsumption)
        {
            this.FuelConsumption = base.FuelConsumption + 0.9;
        }

        protected override void ThrowNoEnoughFuelException()
        {
            throw new ArgumentException("Car needs refueling");
        }

        protected override string ShowMessage(double distance)
        {
            return $"Car travelled {distance} km";
        }
    }
}
