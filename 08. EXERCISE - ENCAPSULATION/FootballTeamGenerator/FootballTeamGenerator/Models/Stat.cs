using FootballTeamGenerator.Exceptions;
using System;

namespace FootballTeamGenerator.Models
{
    public class Stat
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stat(int endurance,int sprint,int dribble,int passing,int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public int Endurance
        {
            get => endurance;

            private set
            {
                Validate(value, nameof(Endurance));

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;

            private set
            {
                Validate(value, nameof(Sprint));

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;

            private set
            {
                Validate(value, nameof(Dribble));

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;

            private set
            {
                Validate(value, nameof(Passing));

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                Validate(value, nameof(Shooting));

                shooting = value;
            }
        }
        public double OverallStat => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        private void Validate(int value, string name)
        {
            if (value < MinStatValue || value > MaxStatValue)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatException, name, MinStatValue, MaxStatValue));
            }
        }
    }
}
