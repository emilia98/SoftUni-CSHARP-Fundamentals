using System;
namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelAmount, double fuelConsumption, double tankCapacity) : base(fuelAmount, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + 1.4);

            this.MoveTheVehicle(fuelNeeded, distance);
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption);

            this.MoveTheVehicle(fuelNeeded, distance);
        }
        
        protected override void ThrowNoEnoughFuelException()
        {
            throw new ArgumentException("Bus needs refueling");
        }

        protected override string ShowMessage(double distance)
        {
            return $"Bus travelled {distance} km";
        }
    }
}