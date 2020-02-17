using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int healt)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = healt;
        }
        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => username;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidUsername);

                username = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidUserHealth);

                health = value;
            }
        }

        public bool IsDead => Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(damagePoints, ExceptionMessages.InvalidDamagePoints);

            Health = Math.Max(Health - damagePoints, 0);
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.PlayerReportInfo, Username, Health, CardRepository.Count);
        }
    }
}
