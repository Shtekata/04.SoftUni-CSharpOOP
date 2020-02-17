using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neighbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Neighbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                var gun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                var target = civilPlayers.FirstOrDefault(x => x.IsAlive == true);

                if (target == null)
                {
                    break;
                }

                var damagePoints = gun.Fire();
                target.TakeLifePoints(damagePoints);
            }

            while (true)
            {
                var player = civilPlayers.FirstOrDefault(x => x.IsAlive == true);

                if (player == null)
                {
                    break;
                }

                var gun = player.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                var damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }
    }
}
