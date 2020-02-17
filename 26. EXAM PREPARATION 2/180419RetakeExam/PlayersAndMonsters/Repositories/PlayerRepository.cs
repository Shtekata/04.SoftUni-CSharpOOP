using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            playersByName = new Dictionary<string, IPlayer>();
        }
        public int Count => playersByName.Count;

        public IReadOnlyCollection<IPlayer> Players => playersByName.Values.ToList();

        public void Add(IPlayer player)
        {
            ThrowIfPlayerIsNull(player, ExceptionMessages.NullPlayer);

            if (playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlredyExist, player.Username));
            }

            playersByName.Add(player.Username, player);
        }
        
        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (playersByName.ContainsKey(username))
            {
                player = playersByName[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            ThrowIfPlayerIsNull(player, ExceptionMessages.NullPlayer);

            var hasRemoved = playersByName.Remove(player.Username);

            return hasRemoved;
        }
        private static void ThrowIfPlayerIsNull(IPlayer player, string message)
        {
            if (player == null)
            {
                throw new ArgumentException(message);
            }
        }

    }
}
