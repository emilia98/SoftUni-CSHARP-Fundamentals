using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var trainersData = new Dictionary<string, Trainer>();
        var elementsData = new Dictionary<string, List<string>>();

        while(input != "Tournament")
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if(trainersData.ContainsKey(trainerName) == false)
            {
                trainersData.Add(trainerName, new Trainer(trainerName));
                elementsData.Add(trainerName, new List<string>());
            }

            trainersData[trainerName].AddPokemon(pokemon);
            elementsData[trainerName].Add(pokemonElement);
            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while(input != "End")
        {
            string element = input.Trim();

            foreach(var trainerInfo in trainersData)
            {
                var trainerName = trainerInfo.Key;
                var trainer = trainersData[trainerName];
                var pokemons = trainer.Pokemons;
                int indexOfElement = elementsData[trainerName].IndexOf(element);
                bool hasElement =  indexOfElement > -1 ? true : false;

                if(hasElement)
                {
                    trainersData[trainerName].IncreaseBadges();
                }
                else
                {
                    int pokemonsCount = pokemons.Count;

                    for (int index = 0; index < pokemonsCount; index++)
                    {
                        var pokemon = pokemons[index];
                        int health = pokemon.ReduceHealth();
                        if(health <= 0)
                        {
                            trainer.RemovePokemon(index);
                            elementsData[trainerName].RemoveAt(index);
                            pokemonsCount = pokemons.Count;
                            index--;
                        }
                    }
                }
            }
            input = Console.ReadLine();
        }

        var sortedByBadges = trainersData.OrderByDescending(t => t.Value.Badges);

        foreach(var trainerInfo in sortedByBadges)
        {
            string trainerName = trainerInfo.Key;
            int badges = trainerInfo.Value.Badges;
            int pokemonsCount = trainerInfo.Value.Pokemons.Count;

            Console.WriteLine("{0} {1} {2}", trainerName, badges, pokemonsCount);
        }
    }
}