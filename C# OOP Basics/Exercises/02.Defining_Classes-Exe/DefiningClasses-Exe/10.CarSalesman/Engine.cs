using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        private string model;
        private double power;
        private double? displacement;
        private string efficiency;

        public Engine(string model, double power)
        {
            this.model = model;
            this.power = power;
            this.displacement = null;
            this.efficiency = null;
        }

        public Engine(string model, double power, double displacement) :this(model, power)
        {
            this.displacement = displacement;
        }

        public Engine(string model, double power, string efficiency) :this(model, power)
        {
            this.efficiency = efficiency;
        }

        public Engine(string model, double power, double displacement, string efficiency) : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
        }

        public double Power
        {
            get { return this.power; }
        }

        public double? Displacement
        {
            get { return this.displacement; }
        }

        public string Efficiency
        {
            get { return this.efficiency; }
        }
    }
}
