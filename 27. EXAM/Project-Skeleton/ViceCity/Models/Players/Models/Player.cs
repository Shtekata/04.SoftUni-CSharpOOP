using System;
using ViceCity.Messages;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        protected Player(string name, int lifePoint)
        {
            Name = name;
            LifePoints = lifePoint;
            GunRepository = new GunRepository();
        }
        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlayerName);
                }

                name = value;
            }
        }
        public int LifePoints
        {
            get => lifePoints;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerLifePoints);
                }

                lifePoints = value;
            }
        }
        public IRepository<IGun> GunRepository { get; private set; }

        public bool IsAlive { get; private set; } = true;

        public void TakeLifePoints(int points)
        {
            if (LifePoints - points <= 0)
            {
                LifePoints = 0;
                IsAlive = false;
            }
            else
            {
                LifePoints -= points;
            }
        }
    }
}
