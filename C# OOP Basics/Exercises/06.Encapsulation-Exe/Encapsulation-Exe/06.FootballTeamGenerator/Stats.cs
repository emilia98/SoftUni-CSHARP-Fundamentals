using System;

namespace _06.FootballTeamGenerator
{
    class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                ThrowException(value, "Endurance");
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                ThrowException(value, "Sprint");
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                ThrowException(value, "Dribble");
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            private set
            {
                ThrowException(value, "Passing");
                this.passing = value;
            }
        }

        public int Shooting
        {
            get {  return this.shooting;}
            private set
            {
                ThrowException(value, "Shooting");
                this.shooting = value;
            }
        }

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        private void ThrowException(int value, string statType)
        {
            if(value < 0 || value > 100)
            {
                throw new Exception($"{statType} should be between 0 and 100.");
            }
        }
    }
}
