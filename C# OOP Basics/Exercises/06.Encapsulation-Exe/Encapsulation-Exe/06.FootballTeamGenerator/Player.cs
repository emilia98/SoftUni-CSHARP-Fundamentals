using System;

namespace _06.FootballTeamGenerator
{
    class Player
    {
        private string name;
        private Stats stats;
        
        public string Name
        {
            get { return this.name; }
            set
            {
                if(string.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stats Stats
        {
            get { return this.stats; }
        }

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.stats = stats;
        }
    }
}