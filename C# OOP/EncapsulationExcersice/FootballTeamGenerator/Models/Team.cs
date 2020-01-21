using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
   public class Team
    {

        private string name;
        private List<Player> players;
      
        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameMessage);
                }
                this.name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (players.Count==0)
                {
                    return 0;
                }
                return (int)(Math.Round(this.players.Average(p => p.OverAllSkill), 0));
            }
            
        }


        public void AddPlayer(Player player)
        {
            //if (!players.Contains(player))
            //{
                this.players.Add(player);
            //}
        }

        public void RemovePlayer(string player)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == player);
            if (players.Contains(playerToRemove))
            {
                players.Remove(playerToRemove);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingPlayer,player,this.Name));
            }
        }

        
    }
}
