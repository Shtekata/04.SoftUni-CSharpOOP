using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Messages;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neighbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players.Models;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private const string MainPlayerNameKey = "Vercetti";
        private const int InitialMainPlayerHealthPoints = 100;
        private readonly List<IPlayer> players;
        private readonly GunRepository gunRepository;
        private readonly GangNeighbourhood gangNeighbourhood;
        public Controller()
        {
            players = new List<IPlayer>();
            players.Add(new MainPlayer());
            gunRepository = new GunRepository();
            gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            if (type != nameof(Pistol) && type != nameof(Rifle))
            {
                return OutputMessages.InvalidGun;
            }

            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }

            gunRepository.Add(gun);

            return string.Format(OutputMessages.SuccessfullAddedGun, gun.Name, gun.GetType().Name);
        }

        public string AddGunToPlayer(string name)
        {
            if (gunRepository.Models.Count() == 0)
            {
                return OutputMessages.NoAvailableWeapon;
            }

            if (name == MainPlayerNameKey)
            {
                var playerVercetti = players.FirstOrDefault(x => x.GetType().Name == nameof(MainPlayer));

                var gunVercetti = gunRepository.Models.FirstOrDefault();
                gunRepository.Remove(gunVercetti);

                playerVercetti.GunRepository.Add(gunVercetti);
                return string.Format(OutputMessages.SuccessfullAddWeapodToMainPlayer, gunVercetti.Name);
            }

            if (players.FirstOrDefault(x => x.Name == name) == null)
            {
                return string.Format(OutputMessages.PlayerNotExist);
            }

            var player = players.FirstOrDefault(x => x.Name == name);
            var gun = gunRepository.Models.FirstOrDefault(x => x.CanFire == true);

            gunRepository.Remove(gun);
            player.GunRepository.Add(gun);

            return string.Format(OutputMessages.SuccessfullAddWeaponToCivilPlayer, gun.Name, player.Name);
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            players.Add(player);
            return string.Format(OutputMessages.SuccessfullAddPlayer, player.Name);
        }

        public string Fight()
        {
            var mainPlayer = (MainPlayer)players.FirstOrDefault(x => x.GetType().Name == nameof(MainPlayer));

            var civilPlayers = players.Where(x => x.GetType().Name != nameof(MainPlayer)).ToList();

            gangNeighbourhood.Action(mainPlayer, civilPlayers);

            var sb = new StringBuilder();

            if (civilPlayers.All(x => x.IsAlive == true) && mainPlayer.LifePoints == InitialMainPlayerHealthPoints)
            {
                sb.AppendLine(OutputMessages.EverythingIsOkay);
            }
            else
            {
                sb.AppendLine(OutputMessages.FightHappened);

                sb.AppendLine(string.Format(OutputMessages.TommiLifePoints, mainPlayer.LifePoints));

                sb.AppendLine(string.Format(OutputMessages.KilledPlayers, civilPlayers.Where(x => x.IsAlive == false).Count()));

                sb.AppendLine(string.Format(OutputMessages.LeftPlayers, civilPlayers.Where(x => x.IsAlive == true).Count()));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
