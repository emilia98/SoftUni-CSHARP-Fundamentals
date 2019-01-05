using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class CryoReactor : BaseReactor
    {
        public CryoReactor(int id, IContainer moduleContainer, int cryoProductionIndex)
            : base(id, moduleContainer)
        {
            this.CryoProductionIndex = cryoProductionIndex;
        }
        // The CryoReactor is initialized with an additional property:
        // CryoProductionIndex – an integer.


        public int CryoProductionIndex { get; }

        // If the Reactor is a CryoReactor, you must multiply its energy output by the cryoProductionIndex.
        public override long TotalEnergyOutput
        {
            get
            {
                long totalEnergyFromModules = base.TotalEnergyOutput * this.CryoProductionIndex;

                if (totalEnergyFromModules > base.TotalHeatAbsorbing)
                {
                    totalEnergyFromModules = 0;
                }

                return totalEnergyFromModules;
            }
        }
    }
}