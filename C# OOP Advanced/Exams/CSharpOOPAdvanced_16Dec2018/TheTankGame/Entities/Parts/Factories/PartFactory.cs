namespace TheTankGame.Entities.Parts.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Parts.Factories.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == (partType + "Part"));
            var partInstance = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);
            return partInstance;
        }
    }
}