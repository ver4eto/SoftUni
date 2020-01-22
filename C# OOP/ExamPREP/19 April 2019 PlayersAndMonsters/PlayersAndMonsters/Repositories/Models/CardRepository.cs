using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories.Models
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            string cardName = card.Name;
            if (card==null)
            {
                throw new ArgumentException(ExceptionMessages.CardIsNullExeption);
            }
            else if (this.cards.Select(c=>c.Name).Contains(cardName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAlreadyExistException,card.Name));
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.Cards.FirstOrDefault(c=>c.Name==name);
            if (card==null)
            {
                throw new ArgumentException(ExceptionMessages.CardIsNullExeption);
            }
            return card;

        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardIsNullExeption);
            }
            this.cards.Remove(card);
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ICard item in this.Cards)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
