namespace CosmosX.Entities.Modules.Energy
{
    public class CryogenRod : BaseEnergyModule
    {
        // The CryogenRod is initialized with an additional property:
        //	EnergyOutput – an integer.

        public CryogenRod(int id, int energyOutput) : base(id, energyOutput)
        {
        }
    }
}