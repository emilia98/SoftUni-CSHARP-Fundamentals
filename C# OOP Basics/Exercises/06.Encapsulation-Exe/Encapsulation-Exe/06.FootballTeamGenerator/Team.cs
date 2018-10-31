using System;
using System.Collections.Generic;

namespace _06.FootballTeamGenerator
{
    class Team
    {
        private string name;
        private List<Player> players;
        private double rating;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                this.name = value;
            }
        }

        private List<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public double Rating
        {
            get
            {
                if (this.Players.Count == 0)
                {
                    return 0;
                }

                double totalRatings = 0;

                foreach (var player in this.Players)
                {
                    totalRatings += GetTotalStats(player);
                }

                // Console.WriteLine(totalRatings);
                return totalRatings / this.Players.Count;
            }
            // set { this.rating = value; }
        }

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
            // this.Rating = 0;
        }

        public void AddPlayer(Player player)
        {
            int totalPlayers = this.Players.Count;
            this.Players.Add(player);
            // this.TotalRating += GetTotalStats(player);
            // this.Rating = (this.Rating * totalPlayers + GetTotalStats(player)) / (totalPlayers + 1);
        }

        public void RemovePlayer(string playerName)
        {
            var playerIndex = -1;

            for (int index = 0; index < this.Players.Count; index++)
            {
                Player player = this.Players[index];

                if (player.Name == playerName)
                {
                    playerIndex = index;
                }
            }

            if (playerIndex > -1)
            {
                Player player = this.Players[playerIndex];
                int totalPlayers = this.Players.Count;

                //this.TotalRating -= GetTotalStats(player);
                // this.Rating = (this.Rating * totalPlayers - GetTotalStats(player)) / (totalPlayers - 1);
                this.Players.RemoveAt(playerIndex);
                return;
            }

            Console.WriteLine($"Player {playerName} is not in {this.name} team.");
        }

        private double GetTotalStats(Player player)
        {
            Stats stats = player.Stats;
            int totalStats = stats.Dribble + stats.Endurance + stats.Passing + stats.Shooting + stats.Sprint;
            return totalStats / 5.0;
        }
    }
}