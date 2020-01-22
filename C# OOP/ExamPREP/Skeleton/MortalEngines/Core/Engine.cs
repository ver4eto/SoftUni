using MortalEngines.Core.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MortalEngines.IO.Contracts;
using System.Reflection;

namespace MortalEngines.Core
{
    public class Engine : IEngine

    {
        //private readonly ICommandInterpreter commandInterpreter;
        //private readonly IWriter writer;

        //public Engine(ICommandInterpreter commandInterpreter, IWriter writer)
        //{
        //    this.commandInterpreter = commandInterpreter;
        //    this.writer = writer;
        //}

        //public void Run()
        //{
        //    string input = string.Empty;

        //    while ((input = Console.ReadLine()) != "Quit")
        //    {
        //        string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        //        try
        //        {
        //            string result = this.commandInterpreter.Read(inputArgs);
        //            this.writer.Write(result);
        //        }
        //        catch (TargetInvocationException ex)
        //        {
        //            this.writer.Write($"Error: {ex.InnerException.Message}");
        //        }
        //    }
        //}
        private MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string command = Console.ReadLine();



            while (command != "Quit")
            {
                string[] args = command
                    .Split()
                    .ToArray();

                try
                {
                    if (args.Length == 2)
                    {
                        string currentCommand = args[0];
                        string name = args[1];

                        switch (currentCommand)
                        {
                            case "HirePilot":
                                Console.WriteLine(machinesManager.HirePilot(name));
                                break;
                            case "PilotReport":
                                Console.WriteLine(machinesManager.PilotReport(name));
                                break;
                            case "MachineReport":
                                Console.WriteLine(machinesManager.MachineReport(name));
                                break;
                            case "AggressiveMode":
                                Console.WriteLine(machinesManager.ToggleFighterAggressiveMode(name));
                                break;
                            case "DefenseMode":
                                Console.WriteLine(machinesManager.ToggleTankDefenseMode(name));
                                break;
                            default:
                                break;
                        }
                    }
                    else if (args.Length == 3)
                    {
                        string currentCommand = args[0];

                        switch (currentCommand)
                        {
                            case "Engage":
                                string pilotName = args[1];
                                string machineName = args[2];

                                Console.WriteLine(machinesManager.EngageMachine(pilotName, machineName));

                                break;
                            case "Attack":
                                string attackingMachine = args[1];
                                string defendingMachine = args[2];

                                Console.WriteLine(machinesManager.AttackMachines(attackingMachine, defendingMachine));

                                break;
                            default:
                                break;
                        }
                    }
                    else if (args.Length == 4)
                    {
                        string currentCommand = args[0];
                        string name = args[1];
                        double attack = double.Parse(args[2]);
                        double defense = double.Parse(args[3]);

                        switch (currentCommand)
                        {
                            case "ManufactureTank":

                                Console.WriteLine(machinesManager.ManufactureTank(name, attack, defense));

                                break;
                            case "ManufactureFighter":

                                Console.WriteLine(machinesManager.ManufactureFighter(name, attack, defense));
                                break;
                            default:
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error:{ex.Message}");
                }


                command = Console.ReadLine();
            }
        }
    }
}
