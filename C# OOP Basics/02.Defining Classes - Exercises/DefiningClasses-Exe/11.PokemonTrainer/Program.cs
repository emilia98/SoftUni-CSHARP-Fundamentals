using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var trainersData = new Dictionary<string, Trainer>();

        while(input != "Tournament")
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            var pokemon = new Pokemon()
            {
                Name = pokemonName,
                Element = pokemonElement,
                Health = pokemonHealth
            };
            
            if(!trainersData.ContainsKey(trainerName))
            {
                var trainer = new Trainer();
                trainer.Name = trainerName;
                trainersData.Add(trainerName, trainer);
            }

            trainersData[trainerName].AddPokemon(pokemon);

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "End")
        {
            string element = input.Trim();

            var trainerNames = trainersData.Keys.ToList();

            foreach(var trainerName in trainerNames)
            {
                var trainer = trainersData[trainerName];
                bool hasElement = false;

                var pokemons = trainer.Pokemons;

                foreach(var pokemon in pokemons)
                {
                    if (pokemon.Element == element)
                    {
                        hasElement = true;
                        trainer.Badges += 1;
                        break;
                    }
                }

                if(hasElement == false)
                {
                    int pokemonsCount = pokemons.Count;

                    for (int index = 0; index < pokemonsCount; index++)
                    {
                        var pokemon = pokemons[index];

                        pokemon.Health -= 10;

                        if (pokemon.Health <= 0)
                        {
                            pokemons.RemoveAt(index);
                            index--;
                            pokemonsCount--;
                        }
                    }
                }
            }
            input = Console.ReadLine();
        }

        var sortedByBadges = trainersData.OrderByDescending(t => t.Value.Badges);

        foreach(var trainerData in sortedByBadges)
        {
            string trainerName = trainerData.Value.Name;
            int badges = trainerData.Value.Badges;
            int pokemonsCount = trainerData.Value.Pokemons.Count;
            Console.WriteLine("{0} {1} {2}", trainerName, badges, pokemonsCount);
        }
    }
}

