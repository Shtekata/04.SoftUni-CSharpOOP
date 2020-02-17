using FootballTeamGenerator.Exceptions;
using System;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        public Player(string name, Stat stat)
        {
            Name = name;
            Stat = stat;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                name = value;
            }
        }
        public double OverallSkill => Stat.OverallStat;
        public Stat Stat { get; private set; }
    }
}
