using System;
using System.Collections.Generic;
using System.Text;


    public abstract class Driver
    {
        public string Name { get; private set; }

        public double TotalTime { get; private set; }

        public Car Car { get; private set; }

        public double FuelConsumptionPerKm { get; protected set; }

        public double Speed { get; protected set; }

        protected Driver(string name,Car car)
        {
            this.Name = name;
            this.TotalTime = 0.0;
            this.Car = car;
            this.FuelConsumptionPerKm = 1;
            this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        }
    }
