﻿namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class EndurancePart : BasePart, IHitPointsModifyingPart
    {
        public int HitPointsModifier { get; private set; }

        public EndurancePart(string model, double weight, decimal price, int hitPointsModifier)
            : base(model, weight, price)
        {
            this.HitPointsModifier = hitPointsModifier;
        }
        
        public override string ToString()
        {
            return base.ToString() + $"+{this.HitPointsModifier} HitPoints";
        }
    }
}