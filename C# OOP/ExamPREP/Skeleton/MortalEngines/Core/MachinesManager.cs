namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<Pilot> pilots;
        //private List<Tank> tanks;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<Pilot>();
            //tanks = new List<Tank>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            string result;
            Pilot currentPilot = pilots.FirstOrDefault(p => p.Name == name);

            if (/*pilots.Contains(currentPilot)*/this.pilots.Any(p=>p.Name==name))
            {
                result = string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                Pilot pilot = new Pilot(name);
               this.pilots.Add(pilot);
                result = string.Format(OutputMessages.PilotHired, name);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            string result;
            IMachine tank = machines.FirstOrDefault(t => t.Name == name);

            if (this.machines.Any(t=>t.Name==name))
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                tank = new Tank(name, attackPoints, defensePoints);
               this.machines.Add(tank);
                result = string.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
            }

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            string result;

            IMachine machine = machines.FirstOrDefault(m => m.Name == name /*&& m.GetType().Name == nameof(Fighter)*/);

            if (machine != null)
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);

                machines.Add(fighter);

                result = string.Format(OutputMessages.FighterManufactured,
                    fighter.Name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    fighter.AggressiveMode==true ? "ON" : "OFF");
            }

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {

            StringBuilder sb = new StringBuilder();

            IPilot pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            IMachine machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                sb.AppendLine($"{string.Format(OutputMessages.PilotNotFound, selectedPilotName) }");
            }
          else   if (machine == null)
            {
                sb.AppendLine($"{string.Format(OutputMessages.MachineNotFound, selectedMachineName) }");
            }
            else if (machine != null)
            {
                //IPilot machinePilot = machine.Pilot;
                if (machine.Pilot != null)
                {
                    sb.AppendLine($"{string.Format(OutputMessages.MachineHasPilotAlready, machine.Name)}");
                }
                else if (machine.Pilot == null)
                {
                    pilot.AddMachine(machine);
                    machine.Pilot = pilot;
                    sb.AppendLine($"{string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name)}");
                }
            }




            return sb.ToString().TrimEnd();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            string result;

            IMachine attackingMachine = machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine defendingMachine = machines.FirstOrDefault(m => m.Name == defendingMachineName);
            
            if (attackingMachine==null)
            {
                result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine==null)
            {
                result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attackingMachine.HealthPoints==0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine.Name);
            }
            else if (defendingMachine.HealthPoints==0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine.Name);
            }

            else
            {
                attackingMachine.Attack(defendingMachine);
                result = string.Format(OutputMessages.AttackSuccessful,
                    defendingMachine.Name,
                    attackingMachine.Name,
                    defendingMachine.HealthPoints);
            }

            //if (attackingMachine != null && defendingMachine != null)
            //{
            //    if (attackingMachine.HealthPoints > 0 && defendingMachine.HealthPoints > 0)
            //    {
            //        attackingMachine.Attack(defendingMachine);
            //        result = string.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
            //    }
            //    else
            //    {
            //        if (attackingMachine.HealthPoints <= 0)
            //        {
            //            result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            //        }
            //        else
            //        {
            //            result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            //        }
            //    }
            //}
            //else
            //{
            //    if (attackingMachine == null)
            //    {
            //        result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            //    }
            //    else
            //    {
            //        result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            //    }
            //}

            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            string result;
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            
            if(pilot==null)
            {
                result = string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }
           else
            {

                result = pilot.Report();
            }
            return result;
        }

        public string MachineReport(string machineName)
        {
            IMachine machine =this.machines.FirstOrDefault(m => m.Name == machineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);                
            }
            else
            {
                return machine.ToString();
            }

        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            string result;

            IMachine fighter = machines.FirstOrDefault(f => f.Name == fighterName/* && f.GetType().Name == nameof(Fighter)*/);

            if (/*fighter != null*/machines.Any(m=>m.Name==fighterName))
            {
                //Fighter currFighter =(Fighter) fighter;

                foreach (IFighter item in machines.Where(m=>m.GetType()==typeof(Fighter)).Where(m=>m.Name==fighterName))
                {
                    item.ToggleAggressiveMode();
                }
                //currFighter.ToggleAggressiveMode();

                result = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
            else
            {
                result = string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            string result;

            IMachine machine = machines.FirstOrDefault(t => t.Name == tankName && t.GetType().Name == nameof(Tank));

            if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                ITank currentTank = (ITank)machine;

                currentTank.ToggleDefenseMode();

                result = string.Format(OutputMessages.TankOperationSuccessful, currentTank.Name);
            }

            return result;
        }
    }
}