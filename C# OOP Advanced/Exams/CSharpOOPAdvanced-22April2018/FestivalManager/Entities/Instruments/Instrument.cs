using System;

namespace FestivalManager.Entities.Instruments
{
    using Contracts;

    public abstract class Instrument : IInstrument
    {
        //•	Int  RepairAmount

        private double wear;
        private const int MaxWear = 100;

        protected Instrument()
        {
            this.Wear = MaxWear;
        }

        public double Wear
        {
            get
            {
                return this.wear;
            }
            private set
            {
                // TODO: SHOULD IT BE LIKE THIS
                this.wear = Math.Min(Math.Max(value, 0), 100);
            }
        }

        // TODO: IS IT CORRECT
        protected virtual int RepairAmount { get; }

        public void Repair() => this.Wear += this.RepairAmount;

        public void WearDown() => this.Wear -= this.RepairAmount;

        public bool IsBroken => this.Wear <= 0;

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

            return $"{this.GetType().Name} [{instrumentStatus}]";
        }
    }
}
