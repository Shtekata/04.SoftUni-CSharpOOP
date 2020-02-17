using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cardByName;

        public CardRepository()
        {
            cardByName = new Dictionary<string, ICard>();
        }
        public int Count => cardByName.Count;

        public IReadOnlyCollection<ICard> Cards => cardByName.Values.ToList();

        public void Add(ICard card)
        {
            ThrowIfCardIsNull(card, ExceptionMessages.NullCard);

            if (cardByName.ContainsKey(card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAlreadyExist, card.Name));
            }

            cardByName.Add(card.Name, card);
        }
        
        public ICard Find(string name)
        {
            ICard card = null;

            if (cardByName.ContainsKey(name))
            {
                card = cardByName[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            ThrowIfCardIsNull(card, ExceptionMessages.NullCard);

            var hasRemoved = cardByName.Remove(card.Name);

            return hasRemoved;

        }
        private static void ThrowIfCardIsNull(ICard card, string message)
        {
            if (card == null)
            {
                throw new ArgumentException(message);
            }
        }

    }
}
