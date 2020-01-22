using MortalEngines.Entities.Contracts;
using MortalEngines.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public class BaseMachine : IMachine
    {
        private string name;
        private  IPilot pilot;
       

            private BaseMachine()
        {
            this.Targets = new List<string>();
        }

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
            :this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
         
        }

        public string Name
        {
            get
            {
                return this.name;
            }
          private  set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessage.InvalidMachineNameException);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value ?? throw new NullReferenceException(ExceptionMessage.PilotIsNullException);
            }
        }
        public double HealthPoints { get; set; }
       

        public double AttackPoints { get; protected set; }       

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessage.TargetIsNullException);
            }

            double diffAttackerAttackPointsAndTargetDeffence = this.AttackPoints - target.DefensePoints;

            target.HealthPoints -= diffAttackerAttackPointsAndTargetDeffence;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");
            sb.Append(" *Targets: ");
            if (this.Targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine(string.Join(",",this.Targets));
               
            }
            return sb.ToString().TrimEnd();
        }
    }
}
