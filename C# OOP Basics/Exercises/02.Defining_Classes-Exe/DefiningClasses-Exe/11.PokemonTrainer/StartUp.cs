using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            var trainersData = new Dictionary<string, Trainer>();
            var elementsStats = new Dictionary<string, Dictionary<string, List<Pokemon>>>();

            string input = Console.ReadLine();

            while(input != "Tournament")
            {
                var tokens = input.Split(new char[] { ' ' }, 
                                         StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if(trainersData.ContainsKey(trainerName) == false)
                {
                    var trainer = new Trainer(trainerName);
                    trainersData.Add(trainerName, trainer);
                    elementsStats.Add(trainerName, new Dictionary<string, List<Pokemon>>());

                    elementsStats[trainerName].Add("Fire", new List<Pokemon>());
                    elementsStats[trainerName].Add("Water", new List<Pokemon>());
                    elementsStats[trainerName].Add("Electricity", new List<Pokemon>());
                }

                
              
                



                //elementsStats[trainerName][pokemonElement] += 1;

                // Console.WriteLine("EL: " + pokemonElement);
                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainersData[trainerName].AddPokemon(pokemon);

                if (elementsStats[trainerName].ContainsKey(pokemonElement))
                {
                    elementsStats[trainerName][pokemonElement].Add(pokemon);
                }
                input = Console.ReadLine();
            }

            /*
            foreach(var trainer in elementsStats)
            {
                Console.WriteLine(trainer.Key);
                
                foreach(var data in trainer.Value)
                {
                    Console.WriteLine(data.Key + " " + data.Value.Count);
                }
            }
            */
            string command = Console.ReadLine();

            while(command != "End")
            {
                if(command == "Fire" || command == "Water" || command == "Electricity")
                {
                    foreach(var data in elementsStats)
                    {
                        string trainer = data.Key;

                        if(elementsStats[trainer][command].Count > 0)
                        {
                            trainersData[trainer].AddOneBadge();
                        }
                        else
                        {
                            trainersData[trainer].RemovePokemons();

                            // var trainerPokemons = trainersData[trainer].Pokemons;
                            /*
                            foreach (var me in elementsStats[trainer])
                            {
                                if(me.Key != command)
                                {
Console.WriteLine(me.Key + " " + me.Value.Count);
                                }
                                
                                // Console.WriteLine(pokemon.Name + " " + pokemon.Health);
                            }
                            */

                            // elementsStats[trainer]

                       /* foreach (var pokemon in trainerPokemons)
                            {
                                
                                Console.WriteLine(pokemon.Name + " " + pokemon.Element);
                            }
                            */
                            
                           

                            
                            
                        }
                    }
                }
                command = Console.ReadLine();
            }

            var sortedData = trainersData.OrderByDescending(x => x.Value.Badges)
                                         .ToDictionary(x => x.Key, x => x.Value);

            foreach(var data in sortedData)
            {
                string trainerName = data.Key;
                var trainerData = data.Value;

                int pokemonsCount = trainerData.Pokemons.Where(p => p != null).Count();
                Console.WriteLine($"{trainerName} {trainerData.Badges} {pokemonsCount}");
            }
        }
    }
}