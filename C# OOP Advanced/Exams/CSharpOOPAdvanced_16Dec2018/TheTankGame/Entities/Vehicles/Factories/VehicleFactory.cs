namespace TheTankGame.Entities.Vehicles.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Vehicles.Contracts;
    using Factories.Contracts;
    using TheTankGame.Entities.Miscellaneous;

    public class VehicleFactory : IVehicleFactory
    {

        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == vehicleType);
            var vehicleInstance = (IVehicle)Activator.CreateInstance(type, 
                model, weight, price, attack, defense, hitPoints, new VehicleAssembler());

            return vehicleInstance;
        }
    }
}