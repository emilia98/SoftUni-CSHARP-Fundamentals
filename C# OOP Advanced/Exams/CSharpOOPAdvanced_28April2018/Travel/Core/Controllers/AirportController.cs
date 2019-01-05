namespace Travel.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private IAirport airport;

        private IAirplaneFactory airplaneFactory = null;
        private IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;
            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        //        RegisterPassenger {username}
        //    If the airport already has a passenger with that username,
        // throw an InvalidOperationException with the message "Passenger {username} already registered!".
        //The command adds a new passenger into the airport and returns "Registered {passenger.Username}"
        public string RegisterPassenger(string username)
        {
            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            var passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }

        //  Gets a passenger with the provided username from the airport.
        // Then, creates a bag with all the provided items and adds it to the passenger’s bags.
        // The command returns "Registered bag with item1, item2, itemN for {username}"
        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            var passenger = this.airport.GetPassenger(username);

            var items = bagItems.Select(x => this.itemFactory.CreateItem(x)).ToArray();
            //var items = new List<IItem>();

            //foreach (var itemName in bagItems)
            //{
            //    var currentItem = this.itemFactory.CreateItem(itemName);
            //    items.Add(currentItem);
            //}

            var bag = new Bag(passenger, items);

            passenger.Bags.Add(bag);
            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }

        // RegisterTrip {source} {destination} {planeType}
        //Creates a trip with that source and destination and adds it to the airport.The Id is auto-generated from the Trip class itself.
        //The command returns "Registered trip {tripId}".
        public string RegisterTrip(string source, string destination, string planeType)
        {
            var airplane = this.airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        // CheckIn {username} {tripId} {bagIndex1}, {bagIndex2}, {bagIndexN}
        // Gets a passenger with the provided username and a trip with the provided id.
        // If the passenger has already checked in (is already in any trips’ airplanes), 
        // throw an InvalidOperationException with the message "{username} is already checked in!". 
        // Then, the command checks in all the passenger bags with that index.
        // Checking in works like this:
        // The bag with that index gets removed from the passenger’s bags.Then, depending on whether the bag should be confiscated, one of the following things happens:
        // If it should be confiscated (if the total value of the bag is over $3000), 
        // the bag is added to the airport’s confiscated bags.If not, the bag gets added to the airport’s checked bags.
        //  Any other bags, whose indices are not listed in the command input are left with the passenger(and eventually board the plane along with the passenger).
        // After checking in any bags, the passenger is added to the trip.
        // The command returns "Checked in {username} with {bagsToCheckInCount-confiscatedBagsCount}/{bagsToCheckInCount} checked in bags".
        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
        {
            var passenger = this.airport.GetPassenger(username);
            var trip = this.airport.GetTrip(tripId);

            var checkedIn = trip.Airplane.Passengers.Any(p => p.Username == username);

            if (checkedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

            var confiscatedBags = CheckInBags(passenger, bagIndices);
            trip.Airplane.AddPassenger(passenger);

            return
                $"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
        }

        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagIndices)
        {
            var bags = passenger.Bags;
            var confiscatedBagCount = 0;

            foreach (var indexToCheck in bagIndices)
            {
                var currentBag = bags[indexToCheck];
                bags.RemoveAt(indexToCheck);

                if (ShouldConfiscate(currentBag))
                {
                    airport.AddConfiscatedBag(currentBag);
                    confiscatedBagCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            return confiscatedBagCount;
        }

        private static bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = 0;

            for (int i = 0; i < bag.Items.Count; i++)
            {
                luggageValue += bag.Items.ToArray()[i].Value;
            }

            var shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }

        InvalidOperationException newException = new InvalidOperationException(new string(
            new[]
            {
                32, 105, 115, 32, 97, 108, 114,
                101, 97, 100, 121, 32, 99, 104,
                101, 99, 107, 101, 100, 32, 105,
                110, 33
            }.Select(c => (char)c).ToArray()));
    }
}