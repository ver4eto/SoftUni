using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Models
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePOints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CardInvalidNameExeption);
                }
                this.name = value;
            }
        }


        public int DamagePoints
        {
            get => this.damagePOints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CardInvalidDamagePointsExeption);
                }
                this.damagePOints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.CardInvalidHealthPointsException);
                }
                this.healthPoints = value;
            }
        }
        public override string ToString()
        {
            return $"Card: {this.Name} - Damage: {this.DamagePoints}";
        }
    }
}
