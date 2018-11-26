using System;
using System.Collections.Generic;
using System.Text;

//namespace GrandPrix
// {
    public class AggressiveDriver : Driver
    {
        public AggressiveDriver(string name, Car car) : base(name, car)
        {
            this.FuelConsumptionPerKm = 2.7;
            this.Speed = ((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount) * 1.3;
       // Console.WriteLine("Speeeed = {0}", this.Speed);

 //        Console.WriteLine();
        }

    public override void ChangeSpeed()
    {
      /*  if(this.Car.FuelAmount == 0)
        {
            this.Speed = 0;
            return;
        }*/
        this.Speed = ((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount) * 1.3;
    }
}
//}
