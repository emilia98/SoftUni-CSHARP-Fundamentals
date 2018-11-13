using System;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelAmount, double fuelConsumption, double tankCapacity) : base(fuelAmount, fuelConsumption, tankCapacity)
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