using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Models
{
    public class Beginner : Player
    {
        private const int INITIA_HEALTH_POINTS = 50;
        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, INITIA_HEALTH_POINTS)
        {
        }
    }
}
