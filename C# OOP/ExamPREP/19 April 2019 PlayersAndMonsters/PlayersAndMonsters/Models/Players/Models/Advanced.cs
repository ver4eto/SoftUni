﻿using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Models
{
    public class Advanced : Player
    {
        private const int INITIAL_HEALTH_POINTS = 250;
        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, INITIAL_HEALTH_POINTS)
        {
        }
    }
}
