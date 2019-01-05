using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class HeatReactor : BaseReactor
    {
        // The HeatReactor is initialized with an additional property:
        // HeatReductionIndex – an integer.

        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(id, moduleContainer)
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get;}

        // TODO: CHECK THIS AND WHAT IT RETURNS
        // If the Reactor is a HeatReactor, you must add the heatReduction to the heat absorbing.
        public override long TotalEnergyOutput
        {
            get
            {
                long totalHeatAbsorbingFromModules = base.TotalHeatAbsorbing + this.HeatReductionIndex;

                if(base.TotalEnergyOutput > totalHeatAbsorbingFromModules)
                {
                    return 0;
                }

                return base.TotalEnergyOutput;
            }
        }

        public override long TotalHeatAbsorbing 
            => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}