namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Models.BattleFields.Models;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards.Models;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories.Models;

    public class ManagerController : IManagerController
    {
        private PlayerRepository players;
        private CardRepository cards;
        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            ICardRepository cardRepository = new CardRepository();
            IPlayer player;

            if (type=="Advanced")
            {
             player = new Advanced(cardRepository,username);

            }
            else
            {
                player = new Beginner(cardRepository, username);
            }

            this.players.Add(player);

            return $"Successfully added player of type {player.GetType().Name} with username: {player.Username}";

        }

        public string AddCard(string type, string name)
        {
            ICard card;
            if (type=="Magic")
            {
                card = new MagicCard(name);
            }
            else
            {
                card = new TrapCard(name);
            }
            this.cards.Add(card);

            return $"Successfully added card of type {card.GetType().Name} with name: {card.Name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.players.Find(username);
            ICard card = this.cards.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {card.Name} to user: {player.Username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.players.Find(attackUser);
            IPlayer enemy = this.players.Find(enemyUser);

            BattleField battleField = new BattleField();

            battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
         return   this.players.ToString();
        }
    }
}
