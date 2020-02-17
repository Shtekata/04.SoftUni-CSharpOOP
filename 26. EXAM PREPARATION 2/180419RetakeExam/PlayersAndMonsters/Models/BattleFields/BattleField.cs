using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }

            if (attackPlayer is Beginner)
            {
                BoostBeginerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                BoostBeginerPlayer(enemyPlayer);
            }

            BoostPlayer(attackPlayer);

            BoostPlayer(enemyPlayer);

            var attackerPlayerDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

            var enemyPlayerDamage = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);


            while (true)
            {
                enemyPlayer.TakeDamage(attackerPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BoostPlayer(IPlayer player)
        {
            var attackPlayerBonusHealth = player.CardRepository.Cards.Sum(x => x.HealthPoints);

            player.Health += attackPlayerBonusHealth;
        }

        private void BoostBeginerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (var item in player.CardRepository.Cards)
            {
                item.DamagePoints += 30;
            }
        }
    }
}
