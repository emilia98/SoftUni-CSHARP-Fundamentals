namespace Travel
{
    using Travel.Core;
    using Travel.Core.Controllers;
    using Travel.Core.IO;
    using Travel.Core.IO.Contracts;
    using Travel.Entities;

    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var airport = new Airport();
            var airportController = new AirportController(airport);
            var flightController = new FlightController(airport);

            var engine = new Engine(reader, writer, airportController, flightController);

            engine.Run();
        }
    }
}