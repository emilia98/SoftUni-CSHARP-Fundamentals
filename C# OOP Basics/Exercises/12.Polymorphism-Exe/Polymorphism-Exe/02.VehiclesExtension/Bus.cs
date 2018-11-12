using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public bool IsEmpty { get; private set; }

        public Bus(double fuelAmount, double fuelConsumption, bool isEmpty) : base(fuelAmount, fuelConsumption)
        {
            this.IsEmpty = isEmpty;

            if (this.IsEmpty == false)
            {
                this.FuelConsumption = base.FuelConsumption + 1.4;
            }
        }
    }
}
