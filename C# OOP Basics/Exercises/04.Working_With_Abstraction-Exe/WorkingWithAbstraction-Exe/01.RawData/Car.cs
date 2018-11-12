using System.Collections.Generic;

namespace _01.RawData
{
    class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public KeyValuePair<double, int>[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = new KeyValuePair<double, int>[] {
                KeyValuePair.Create(tires[0].Pressure, tires[0].Age),
                KeyValuePair.Create(tires[1].Pressure, tires[1].Age),
                KeyValuePair.Create(tires[2].Pressure, tires[2].Age),
                KeyValuePair.Create(tires[3].Pressure, tires[3].Age)
                };
        }
    }
}
