using CosmosX.Entities.Modules.Energy.Contracts;

namespace CosmosX.Entities.Modules.Energy
{
    public abstract class BaseEnergyModule : BaseModule, IEnergyModule
    {
        protected BaseEnergyModule(int id, int energyOutput)
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        // TODO: Should it have a setter???
        public int EnergyOutput { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Energy Output: {this.EnergyOutput}";
        }
    }
}