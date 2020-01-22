using MortalEngines.Entities.Contracts;
using MortalEngines.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public class Pilot : IPilot
    {
        private List<IMachine> machines;
        private string name;

        private Pilot()
        {
            this.machines = new List<IMachine>();
        }

        public Pilot(string name)    
            :this()
        {
            this.Name = name;
            
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessage.PilotInvalidNameException);
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine==null)
            {
                throw new NullReferenceException(ExceptionMessage.MachineNullException);
            }
            this.machines.Add(machine);
        }

        public string Report()
        {         
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");
            foreach (var machine in this.machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
