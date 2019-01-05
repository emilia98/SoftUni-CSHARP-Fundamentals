namespace CosmosX.Tests
{
    //using CosmosX.Entities.Containers;
    //using CosmosX.Entities.Modules.Absorbing;
    //using CosmosX.Entities.Modules.Absorbing.Contracts;
    //using CosmosX.Entities.Modules.Contracts;
    //using CosmosX.Entities.Modules.Energy;
    //using CosmosX.Entities.Modules.Energy.Contracts;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ModuleContainerTests
    {
        // Test if gets TotalEnergyOutput
        // Test if gets TotalHeatAbsorbing
        // Test If returns the ModulesByInput correct
        // Test Adding EnergyModule
        // Test Adding AbsorbingModule
        // Test adding more modules than capacity


        //        Reactor Heat 250 10
        //Module 1 CryogenRod 140
        //Reactor Cryo 25 5
        //Module 1 CryogenRod 109


        [Test]
        public void TestModuleContainer()
        {
            var moduleContainer = new ModuleContainer(5);

            List<IModule> modules = new List<IModule>()
            {
                new CooldownSystem(1, 10000), new CryogenRod(2, 140), new CryogenRod(3, 140),
                new CryogenRod(4, 140), new CryogenRod(5, 140), new HeatProcessor(6, 20000)
            };

            foreach (var module in modules)
            {
                if (module.GetType().Name == "CooldownSystem" || module.GetType().Name == "HeatProcessor")
                {
                    moduleContainer.AddAbsorbingModule((IAbsorbingModule)module);
                }
                else
                {
                    moduleContainer.AddEnergyModule((IEnergyModule)module);
                }

            }


            modules.RemoveAt(0);

            int index = 0;
            foreach (var module in moduleContainer.ModulesByInput)
            {
                Assert.AreEqual(module, modules[index]);
                index++;
            }

            long expectedEnergy = 560;
            long actualEnergy = moduleContainer.TotalEnergyOutput;

            long expectedHeat = 20000;
            long actualHeat = moduleContainer.TotalHeatAbsorbing;


            Assert.AreEqual(5, moduleContainer.ModulesByInput.Count);
            Assert.AreEqual(expectedEnergy, actualEnergy, "Invalid energy");
            Assert.AreEqual(expectedHeat, actualHeat, "Invalid heat");
        }
    }
}