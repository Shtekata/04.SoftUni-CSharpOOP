using FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team()
        {
            players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            Name = name;
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
        public int Raiting
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(players.Average(x => x.OverallSkill));
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var player = players.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingPlayerException, name, Name));
            }

            players.Remove(player);
        }
        public override string ToString()
        {
            return $"{Name} - {Raiting}";
        }
    }
}
