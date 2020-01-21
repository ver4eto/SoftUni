using System;
using FootballTeamGenerator.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Stat
    {
        private const int min = 0;
        private const int max = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (!IsValidInput(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage,nameof(this.Endurance),min,max));
                }
                this.endurance = value;
            }
        }

        private bool IsValidInput(int value)
        {
            if (value>=min && value<=max)
            {
                return true;
            }
            return false;
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (!IsValidInput(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(this.Sprint),min,max));
                }
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
           private set
            {
                if (!IsValidInput(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(this.Dribble),min,max));
                }
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                if (!IsValidInput(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(this.Passing),min,max));
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (!IsValidInput(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(this.Shooting),min,max));
                }
                this.shooting = value;
            }
        }

        public double OverallStat => (this.Passing + this.Shooting + this.Sprint + this.Endurance + this.Dribble) / 5.0;

    }
}
