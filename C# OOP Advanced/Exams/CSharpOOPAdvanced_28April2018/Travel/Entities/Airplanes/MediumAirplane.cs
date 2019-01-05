namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        // MediumAirplane – 10 seats, 14 baggage compartments
        private const int MediumAirplaneSeats = 10;
        private const int MediumAirplaneBaggageCompartments = 14;

        public MediumAirplane() : base(MediumAirplaneSeats, MediumAirplaneBaggageCompartments)
        {
        }
    }
}