using System;
using System.Collections.Generic;
using System.Linq;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;

namespace CosmosX.Entities.Containers
{
    public class ModuleContainer : IContainer
    {
        //The ModuleContainer contains 3 collections – 2 for the Energy and Absorbing Modules, 
        // and one to follow the order of input of the Modules. 

        //The class exposes 2 methods for adding Modules – one for the Energy Modules and one for the Absorbing Modules.

        // Before adding an element, the methods check if there is capacity for it. 
        // If there is not enough capacity, the first element entered is removed, to make space for the new one.
        private int moduleCapacity;
        private IList<IModule> modulesByInput;
        private IDictionary<int, IEnergyModule> energyModules;
        private IDictionary<int, IAbsorbingModule> absorbingModules;

        public ModuleContainer(int moduleCapacity)
        {
            this.moduleCapacity = moduleCapacity;
            this.modulesByInput = new List<IModule>();
            this.energyModules = new Dictionary<int, IEnergyModule>();
            this.absorbingModules = new Dictionary<int, IAbsorbingModule>();
        }

        // Test if gets TotalEnergyOutput
        // Test if gets TotalHeatAbsorbing
        // Test If returns the ModulesByInput correct
        // Test Adding EnergyModule
        // Test Adding AbsorbingModule
        // Test adding more modules than capacity
        public long TotalEnergyOutput
            => this.energyModules.Values.Select(m => m.EnergyOutput).Sum();

        public long TotalHeatAbsorbing
            => this.absorbingModules.Values.Select(m => m.HeatAbsorbing).Sum();

        public IReadOnlyCollection<IModule> ModulesByInput
            => this.modulesByInput.ToList().AsReadOnly();

        public void AddEnergyModule(IEnergyModule energyModule)
        {
            if (energyModule == null)
            {
                throw new ArgumentException();
            }

            if (this.ModulesByInput.Count == this.moduleCapacity)
            {
                this.RemoveOldestModule();
            }

            this.energyModules.Add(energyModule.Id, energyModule);
            this.modulesByInput.Add(energyModule);
        }

        public void AddAbsorbingModule(IAbsorbingModule absorbingModule)
        {
            if (absorbingModule == null)
            {
                throw new ArgumentException();
            }

            if (this.ModulesByInput.Count == this.moduleCapacity)
            {
                this.RemoveOldestModule();
            }

            this.absorbingModules.Add(absorbingModule.Id, absorbingModule);
            this.modulesByInput.Add(absorbingModule);
        }

        private void RemoveOldestModule()
        {
            int removeId = this.modulesByInput[0].Id;

            this.modulesByInput.RemoveAt(0);

            if (this.energyModules.ContainsKey(removeId))
            {
                this.energyModules.Remove(removeId);
                return;
            }

            if (this.absorbingModules.ContainsKey(removeId))
            {
                this.absorbingModules.Remove(removeId);
            }
        }
    }
}