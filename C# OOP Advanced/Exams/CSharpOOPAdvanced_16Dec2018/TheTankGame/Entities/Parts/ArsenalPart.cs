namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class ArsenalPart : BasePart, IAttackModifyingPart
    {
        public int AttackModifier { get; private set; }

        public ArsenalPart(string model, double weight, decimal price, int attackModifier)
            : base(model, weight, price)
        {
            this.AttackModifier = attackModifier;
        }

        public override string ToString()
        {
            return base.ToString() + $"+{this.AttackModifier} Attack";
        }
    }
}