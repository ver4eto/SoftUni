using MortalEngines.Entities.Contracts;
using System;


namespace MortalEngines.Entities.Models
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HEALTH_POINTS = 100;
        private const double ATTACKPOINTS_CHANGE_VALUE = 40;
        private const double DEFENCEPOINTS_CHANGE_VALUE = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints/*-ATTACKPOINTS_CHANGE_VALUE*/, defensePoints/*+DEFENCEPOINTS_CHANGE_VALUE*/, INITIAL_HEALTH_POINTS)
        {
            //this.DefenseMode = true;
            this.ToggleDefenseMode();
        }
        public bool DefenseMode
        {
            get;
            private set;
            
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode==true)
            {
                this.DefenseMode = false;

                this.AttackPoints += ATTACKPOINTS_CHANGE_VALUE;
                this.DefensePoints -= DEFENCEPOINTS_CHANGE_VALUE;
            }
            else
            {
                this.DefenseMode = true;

                this.AttackPoints -= ATTACKPOINTS_CHANGE_VALUE;
                this.DefensePoints += DEFENCEPOINTS_CHANGE_VALUE;
            }
        }

        public override string ToString()
        {
            string result;

            if (this.DefenseMode == true)
            {
                result = base.ToString() + Environment.NewLine + " *Defense: ON";
            }
            else
            {
                result = base.ToString() + Environment.NewLine + " *Defense: OFF";
            }

            return result;
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.ToString());
            //sb.Append(" *Defense: ");
            //if (this.DefenseMode == true)
            //{
            //    sb.AppendLine("ON");
            //}
            //else
            //{
            //    sb.AppendLine("OFF");
            //}
            //return sb.ToString().TrimEnd();
        }
    }
}
