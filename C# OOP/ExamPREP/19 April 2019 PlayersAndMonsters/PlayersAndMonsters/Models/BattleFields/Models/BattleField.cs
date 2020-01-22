using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields.Models
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayerException);
            }
            if (attackPlayer.GetType().Name=="Beginner")
            {
                attackPlayer.Health += 40;
                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name=="Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            //int count = 1;
            while (true)
            {
                int damagePointsAttacker = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                int damagePointsEnemy = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                int futureEnemyHealth = enemyPlayer.Health - damagePointsAttacker;
                if (futureEnemyHealth < 0)
                {
                    enemyPlayer.Health = 0;
                    break;
                }
                else
                {
                    enemyPlayer.TakeDamage(damagePointsAttacker);

                }

                int futureAttackerHealth = attackPlayer.Health - damagePointsEnemy;
                if (futureAttackerHealth < 0)
                {
                    attackPlayer.Health = 0;
                    break;
                }
                else
                {
                    attackPlayer.TakeDamage(damagePointsEnemy);

                }
                //count--;
            }
           
        }
    }
}
