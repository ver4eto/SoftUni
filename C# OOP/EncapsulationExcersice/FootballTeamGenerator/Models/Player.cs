using FootballTeamGenerator.Exceptions;
using System;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
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
        public Stat Stat
        {
            get; set;
        }

        public double OverAllSkill => this.Stat.OverallStat;
    }
}
