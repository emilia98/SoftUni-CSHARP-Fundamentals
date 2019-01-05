namespace Travel.Entities.Airplanes
{
    using Airplanes.Contracts;
    using System;
    using System.Collections.Generic;
    using Entities.Contracts;
    using System.Linq;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        public IReadOnlyCollection<IBag> BaggageCompartment { get => this.baggageCompartment.AsReadOnly(); }

        public IReadOnlyCollection<IPassenger> Passengers { get => this.passengers.AsReadOnly(); }

        // TODO: add fields
        public int BaggageCompartments { get; }

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public int Seats { get; }

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            //TODO: If index is out of range

            IPassenger passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var bags = this.baggageCompartment.Where(x => x.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return bags;
        }

        public void LoadBag(IBag bag)
        {
            if(this.BaggageCompartment.Count >= this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}