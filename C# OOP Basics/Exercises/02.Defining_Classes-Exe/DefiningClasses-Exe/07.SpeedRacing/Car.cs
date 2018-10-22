using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        private string model;
        private double fuelAmount;
        private double consumptionRate;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double consumptionRate)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.consumptionRate = consumptionRate;
            this.travelledDistance = 0;
        }

        public string Model
        {
            get { return this.model; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double ConsumptionRate
        {
            get { return this.consumptionRate; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public void Travel(double distanceToTravel)
        {
            double fuelToUse = distanceToTravel * this.ConsumptionRate;

            if(fuelToUse > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.FuelAmount -= fuelToUse;
            this.TravelledDistance += distanceToTravel;
        }
    }
}
