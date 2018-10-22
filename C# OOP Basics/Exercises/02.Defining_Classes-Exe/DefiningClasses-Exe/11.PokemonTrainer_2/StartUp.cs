using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer_2
{
    public class StartUp
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();

            while(input != "Tournament")
            {
                var tokens = input.Split(new char[] { ' ' },
                                        StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                
                if(trainers.ContainsKey(trainerName) == false)
                {
                    var trainer = new Trainer();
                    trainer.Name = trainerName;
                    trainers.Add(trainerName, trainer);
                }

                var pokemon = new Pokemon();
                pokemon.Name = pokemonName;
                pokemon.Element = pokemonElement;
                pokemon.Health = pokemonHealth;

                trainers[trainerName].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }
            
            string element = Console.ReadLine();

            while(element != "End")
            {
                if(element == "Fire" || element == "Water" || element == "Electricity")
                {
                    foreach(var trainer in trainers.Values)
                    {
                        bool containsElement = false;
                        var pokemons = trainer.Pokemons;

                        foreach(var pokemon in pokemons)
                        {
                            if(pokemon.Element == element)
                            {
                                containsElement = true;
                                break;
                            }
                        }

                        if(containsElement)
                        {
                            trainer.Badges = trainer.Badges + 1;
                            continue;
                        }
                        
                        int pokemonsCount = pokemons.Count;
                        for(int index = 0; index < pokemonsCount; index++)
                        {
                            var pokemon = pokemons[index];
                            pokemon.Health = pokemon.Health - 10;

                            if(pokemon.Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(index);
                                index--;
                                pokemonsCount--;
                            }
                        }
                    }
                }
                element = Console.ReadLine();
            }

            var sortedData = trainers.OrderByDescending(x => x.Value.Badges)
                                     .ToDictionary(x => x.Key, x => x.Value);
           
            foreach(var trainer in sortedData.Values)
            {
                string trainerName = trainer.Name;
                int badges = trainer.Badges;
                int pokemons = trainer.Pokemons.Count;

                Console.WriteLine($"{trainerName} {badges} {pokemons}");
            }
        }
    }
}