using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        private List<IPlayer> players;
        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            string username = player.Username;

            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerIsNullExeption);
            }
            else if (this.players.Select(n=>n.Username).Contains(username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExistException, player.Username));
            }
            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.Players.FirstOrDefault(p=>p.Username==username);
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerIsNullExeption);
            }
            return player;

        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerIsNullExeption);
               
            }
            this.players.Remove(player);
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Players)
            {
                sb.AppendLine(item.ToString());
            }
           

            return sb.ToString().TrimEnd();
        }
    }
}
