using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.OlympicsAreComing
{
    class OlympicsAreComing
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var participantsData = new Dictionary<string, Dictionary<string, int>>();
            var winnersData = new Dictionary<string, int>();

            while(input != "report")
            {
                var tokens = Regex.Split(input, @"\s*\|\s*");

                /* ERROR: MATCH ONLY SPACES< BUT NOT TABS
                string[] playerNames = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] countryNames = tokens[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                */
                string[] playerNames = Regex.Split(tokens[0], @"\s+");
                string[] countryNames = Regex.Split(tokens[1], @"\s+");
                string player = String.Join(" ", playerNames);
                string country = String.Join(" ", countryNames);

                if(participantsData.ContainsKey(country) == false)
                {
                    participantsData.Add(country, new Dictionary<string, int>());
                    winnersData.Add(country, 0);
                }

                winnersData[country] = winnersData[country] + 1;

                if (participantsData[country].ContainsKey(player))
                {
                    participantsData[country][player] = participantsData[country][player] + 1;
                }
                else
                {
                    participantsData[country].Add(player, 1);
                }
                input = Console.ReadLine();
            }
            
            foreach(var data in winnersData.OrderByDescending(c => c.Value).ToList())
            {
                string country = data.Key;
                var countryData = participantsData[country];
                int participantsCount = countryData.Count;
                int wins = data.Value;
                
                Console.WriteLine($"{country} ({participantsCount} participants): {wins} wins");
            }
        }
    }
}
