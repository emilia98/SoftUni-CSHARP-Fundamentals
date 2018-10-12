using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.TicketTrouble
{
    class TicketTrouble
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string text = Console.ReadLine();

            var locationDetails = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string countryCode = locationDetails[0];
            string cityCode = locationDetails[1];

            var pattern = new Regex(@"(?<curly>\{[^\{\}]*?(\[(?<dest>[A-Z]{3}\s*[A-Z]{2})\])[^\{\}]*?(\[(?<seats>[A-Z]{1}\s*[0-9]{1,2})\])[^\{\}]*?\})|(?<square>\[[^\[\]]*?(\{(?<dest2>[A-Z]{3}\s*[A-Z]{2})\})[^\[\]]*?(\{(?<seats2>[A-Z]{1}\s*[0-9]{1,2})\})[^\[\]]*?\])");

            MatchCollection matches = pattern.Matches(text);
            var seatsData = new Dictionary<int, List<string>>();
            var seats = new List<string>();

            foreach (Match match in matches)
            {
                var groups = match.Groups;
                string destination = null;
                string seat = null;


                if (groups["curly"].Success)
                {
                    destination = groups["dest"].Value;
                    seat = groups["seats"].Value;
                }
                else if (groups["square"].Success)
                {
                    destination = groups["dest2"].Value;
                    seat = groups["seats2"].Value;
                }

                var tokens_dest = destination.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string toCountry = tokens_dest[0];
                string toCity = tokens_dest[1];

                int seat_row = int.Parse(seat.Substring(1));
                char seat_col = seat[0];

                if (toCountry == countryCode && toCity == cityCode)
                {
                    seats.Add(seat);
                    if (seatsData.ContainsKey(seat_row) == false)
                    {
                        seatsData.Add(seat_row, new List<string>());
                    }

                    seatsData[seat_row].Add(seat);
                }
            }
            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {countryCode} {cityCode} on seats {seats[0]} and {seats[1]}.");
                return;
            }

            foreach (var seatsRow in seatsData)
            {
                var seatsOnThisRow = seatsRow.Value;
                int seatsCount = seatsOnThisRow.Count;

                if (seatsCount >= 2)
                {
                    Console.WriteLine($"You are traveling to {countryCode} {cityCode} on seats {seatsOnThisRow[0]} and {seatsOnThisRow[1]}.");
                    return;
                }
            }
        }
    }
}
