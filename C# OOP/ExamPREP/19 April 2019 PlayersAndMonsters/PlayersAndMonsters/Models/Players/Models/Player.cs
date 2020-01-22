using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Cards.Models;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players.Models
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;

        //protected Player()
        //{
        //    this.CardRepository = new CardRepository();
        //}
        protected Player(ICardRepository cardRepository, string username, int health)
            //:this()
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository
        {
            get ;/* => this.cardRepository;*/
            private set;
        }
        

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidUsernameException);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHealthException);
                }
                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;
        //{
        //    get
        //    {
        //        if (this.Health>0)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
            
        //}

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints<0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDamagePoints);
            }
            //should not drop below 0

            int futureHealth = this.Health - damagePoints;
            if (futureHealth<=0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health =futureHealth;
            }

            //this.Health = Math.Max(this.Health-damagePoints,0);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Username: {this.Username} - Health: {this.Health} - Cards {this.CardRepository.Count}");
            if (this.CardRepository.Count>0)
            {
                sb.AppendLine(this.CardRepository.ToString());
            }
            
            sb.AppendLine("###");

            return sb.ToString().TrimEnd();
        }
    }
}
