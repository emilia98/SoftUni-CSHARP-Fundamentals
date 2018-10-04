using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.PopulationCounter
{
    class PopulationCounter
    {
        static void Main()
        {
            string input = Console.ReadLine();
            /* HAD ERROR: (RUNTIME ERROR)
             * -> NOT THE RIGHT DATA TYPE
             * Population should be double (or long), int is not appropriate 
             */
            var populationData = new Dictionary<string, Dictionary<string, double>>();

            while (input != "report")
            {
                var tokens = Regex.Split(input, @"\s*\|\s*").Where(x => x != "").ToArray();
                string city = tokens[0];
                string country = tokens[1];
                double population = double.Parse(tokens[2]);

                if (populationData.ContainsKey(country) == false)
                {
                    populationData.Add(country, new Dictionary<string, double>());
                }

                if (populationData.ContainsKey(city) == false)
                {
                    populationData[country].Add(city, 0);
                }

                populationData[country][city] = populationData[country][city] + population;

                input = Console.ReadLine();
            }

            var sortedData = populationData.OrderByDescending(x => x.Value.Values.Sum())
                                           .ToDictionary(x => x.Key,
                                                         x => x.Value.OrderByDescending(y => y.Value)
                                                                     .ToDictionary(y => y.Key,
                                                                                   y => y.Value));
            foreach (var countryData in sortedData)
            {
                string country = countryData.Key;
                var cityData = countryData.Value;
                double countryPopulation = cityData.Sum(x => x.Value);

                Console.WriteLine($"{country} (total population: {countryPopulation})");

                foreach (var pair in cityData)
                {
                    string city = pair.Key;
                    double population = pair.Value;
                    Console.WriteLine($"=>{city}: {population}");
                }
            }
        }
    }
}

/* ANOTHER WAY OF SORTING
            * foreach (var pair in countryData.OrderByDescending(x => x.Value.Values.Sum()))
           {
               var country = pair.Key;
               var citiesData = pair.Value;
               long countryTotalPopulation = citiesData.Values.Sum();

               Console.WriteLine("{0} (total population: {1})", 
                                  country, countryTotalPopulation);

               foreach (var cityData in citiesData.OrderByDescending(x => x.Value))
               {
                   var city = cityData.Key;
                   var cityPopulation = cityData.Value;
                   Console.WriteLine("=>{0}: {1}", city, cityPopulation);
               }
           }
*/
