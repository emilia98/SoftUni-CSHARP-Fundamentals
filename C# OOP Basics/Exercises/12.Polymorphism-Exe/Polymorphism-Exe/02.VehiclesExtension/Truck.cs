using System;

namespace _02.VehiclesExtension
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
            try
            {
                this.CheckFuelAmount(fuelAmount);
                this.FuelAmount += (fuelAmount * 0.95);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
