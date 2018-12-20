namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class ShellPart : BasePart, IDefenseModifyingPart
    {
        //Schedule for the next feature
        public int DefenseModifier { get; private set; }

        public ShellPart(string model, double weight, decimal price, int defenseModifier) : base(model, weight, price)
        {
            this.DefenseModifier = defenseModifier;
        }

        // TODO: ToString()
        public override string ToString()
        {
            return base.ToString() + $"+{this.DefenseModifier} Defense";
        }
    }
}