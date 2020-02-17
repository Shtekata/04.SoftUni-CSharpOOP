namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController(IPlayerFactory playerFactory, IPlayerRepository playerRepository, ICardFactory cardFactory, ICardRepository cardRepository, IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);

            var result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);

            cardRepository.Add(card);

            var result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Find(username);

            var card = cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            var result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);

            battleField.Fight(attacker, enemy);

            var result = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var item in playerRepository.Players)
            {
                sb.AppendLine(item.ToString());

                foreach (var item2 in cardRepository.Cards)
                {
                    sb.AppendLine(item2.ToString());
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
