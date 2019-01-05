namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        // LightAirplane – 5 seats, 8 baggage compartments
        private const int LightAirplaneSeats = 5;
        private const int LightAirplaneBaggageCompartments = 8;

        public LightAirplane() : base(LightAirplaneSeats, LightAirplaneBaggageCompartments)
        {
        }
    }
}