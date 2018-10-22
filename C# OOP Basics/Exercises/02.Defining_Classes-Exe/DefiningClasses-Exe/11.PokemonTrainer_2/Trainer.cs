using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer_2
{
    class Trainer
    {
        private string name;
        private List<Pokemon> pokemons = new List<Pokemon>();
        private int badges = 0;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }
    }
}
