﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer_2
{
    class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }


    }
}
