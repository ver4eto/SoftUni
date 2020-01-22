using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH_POINTS = 200;
        private const double ATTACKPOINTS_CHANGE_VALUE = 50;
        private const double DEFENCEPOINTS_CHANGE_VALUE = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints/*+ATTACKPOINTS_CHANGE_VALUE*/, defensePoints/*-DEFENCEPOINTS_CHANGE_VALUE*/, INITIAL_HEALTH_POINTS)
        {
            //this.AggressiveMode = true; 
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode
        {
            get;
            private set;
                 
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= ATTACKPOINTS_CHANGE_VALUE;
                this.DefensePoints += DEFENCEPOINTS_CHANGE_VALUE;
            }
            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += ATTACKPOINTS_CHANGE_VALUE;
                this.DefensePoints -= DEFENCEPOINTS_CHANGE_VALUE;

            }
        }

        public override string ToString()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
          
            if (this.AggressiveMode == true)
            {
                sb.AppendLine(" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine(" *Aggressive: OFF");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
