using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        private string model;
        private Engine engine;
        private double? weight;
        private string color;
        
        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = null;
            this.color = null;
        }

        public Car(string model, Engine engine, double weight) :this(model, engine)
        {
            this.weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.color = color;
        }

        public Car(string model, Engine engine, double weight, string color) : this(model, engine)
        {
            this.weight = weight;
            this.color = color;
        }

        public string Model
        {
            get { return this.model; }
        }

        public Engine Engine
        {
            get { return this.engine; }
        }

        public double? Weight
        {
            get { return this.weight; }
        }

        public string Color
        {
            get { return this.color; }
        }

        public override string ToString()
        {
            var result = new List<string>();
            string carWeight = this.Weight == null ? "n/a" : this.Weight.ToString();
            string carColor = this.Color == null ? "n/a" : this.Color;
            string displacement = this.Engine.Displacement == null ? "n/a" : this.Engine.Displacement.ToString();
            string efficiency = this.Engine.Efficiency == null ? "n/a" : this.Engine.Efficiency.ToString();

            result.Add($"{this.Model}:");
            result.Add($"  {this.Engine.Model}:");
            result.Add($"    Power: {this.Engine.Power}");
            result.Add($"    Displacement: {displacement}");
            result.Add($"    Efficiency: {efficiency}");
            result.Add($"  Weight: {carWeight}");
            result.Add($"  Color: {carColor}");

            return String.Join("\n", result);
        }
    }
}
