using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public int Badges
        {
            get { return this.badges; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
        }
        
        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void AddOneBadge()
        {
            this.badges++;
        }

        public void RemovePokemons()
        {
            int pokemonsCount = this.Pokemons.Count;
            for(int index = 0; index < pokemonsCount; index++)
            {
                var pokemon = this.Pokemons[index];

                if(pokemon == null)
                {
                    continue;
                }
                pokemon.DecreaseHealth();

                if (pokemon.Health <= 0)
                {
                    /*
                    this.Pokemons.RemoveAt(index);
                    pokemonsCount--;
                    index--;*/
                    this.Pokemons[index] = null;
                }
            }
        }
    }
}