using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healtPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidCardName);

                name = value;
            }
        }

        public int DamagePoints
        {
            get => damagePoints;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidCardDamagePoints);

                damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => healtPoints;
            private set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidCardHealthPoints);

                healtPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.CardReportInfo, Name, DamagePoints);
        }
    }
}
